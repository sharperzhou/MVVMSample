using MVVM2.Models;
using Prism.Mvvm;

namespace MVVM2.ViewModels
{
    public class DishMenuItemViewModel : BindableBase
    {
        /// <summary>
        /// Dish
        /// </summary>
        public Dish Dish { get; set; }

        private bool _isSelected;

        /// <summary>
        /// Is selected Dish
        /// </summary>
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                RaisePropertyChanged(nameof(IsSelected));
            }
        }
    }
}