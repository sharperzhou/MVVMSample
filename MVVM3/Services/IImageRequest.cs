using System.Collections.Generic;
using System.Net;
using MVVM3.Models;

namespace MVVM3.Services
{
    public interface IImageRequest
    {
        string SearchTerm { get; set; }
        string Url { get; }
        IEnumerable<SearchItemResult> Parse(string xml);
        ICredentials Credentials { get; }
    }
}