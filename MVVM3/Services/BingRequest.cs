using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using MVVM3.Models;

namespace MVVM3.Services
{
    public class BingRequest : IImageRequest
    {
        public string SearchTerm { get; set; }

        public string Url => $@"https://api.datamarket.azure.com/
                              Data.ashx/Bing/Search/v1/Image?Query=%27{SearchTerm}%27&
                              $top={Count}&$skip={Offset}&format=Atom";

        public IEnumerable<SearchItemResult> Parse(string xml)
        {
            var respXml = XElement.Parse(xml);
            var d = XNamespace.Get("http://schemas.microsoft.com/ado/2007/08/dataservices");
            var m = XNamespace.Get("http://schemas.microsoft.com/ado/2007/08/dataservices/metadata");

            return respXml.Descendants(m + "properties").Select(item => new SearchItemResult
            {
                Title = new string(item.Element(d + "Title")?.Value.Take(50).ToArray()),
                Url = item.Element(d+ "MediaUrl")?.Value,
                ThumbnailUrl = item.Element(d+ "Thumbnail")?.Element(d+ "MediaUrl")?.Value,
                Source = "Bing"
            }).ToList();
        }

        public ICredentials Credentials => new NetworkCredential(AppId, AppId);

        public int Count { get; set; } = 50;
        public int Offset { get; set; } = 0;

        private const string AppId = "";
    }
}