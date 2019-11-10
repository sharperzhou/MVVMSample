using System.Collections.ObjectModel;
using System.Runtime.Loader;
using MVVM3.Models;
using Prism.Mvvm;

namespace MVVM3.ViewModels
{
    public class SearchInfo : BindableBase
    {
        public SearchInfo()
        {
            _list = new ObservableCollection<SearchItemResult>();
            _list.CollectionChanged += (sender, e) => RaisePropertyChanged(nameof(List));
        }
        
        private string _searchTerm;

        public string SearchTerm
        {
            get => _searchTerm;
            set => SetProperty(ref _searchTerm, value);
        }

        private ObservableCollection<SearchItemResult> _list;
        public ObservableCollection<SearchItemResult> List => _list;
    }
}