using Prism.Mvvm;

namespace MVVM3.Models
{
    public class SearchItemResult : BindableBase
    {
        private string _title;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _url;

        public string Url
        {
            get => _url;
            set => SetProperty(ref _url, value);
        }

        private string _thumbnailUrl;

        public string ThumbnailUrl
        {
            get => _thumbnailUrl;
            set => SetProperty(ref _thumbnailUrl, value);
        }

        private string _source;

        public string Source
        {
            get => _source;
            set => SetProperty(ref _source, value);
        }
    }
}