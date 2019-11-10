using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using MVVM2.Models;
using MVVM2.Services;
using Prism.Commands;
using Prism.Mvvm;

namespace MVVM2.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            LoadRestaurant();
            LoadDishMenu();
        }

        /// <summary>
        /// Place order command
        /// </summary>
        public ICommand PlaceOrderCommand => new DelegateCommand(() =>
        {
            var selectedDishes = DishMenu.Where(i => i.IsSelected).Select(i => i.Dish.Name).ToList();
            IOrderService orderService = new MockOrderService();
            orderService.PlaceOrder(selectedDishes);
            MessageBox.Show("订单成功！");
        });

        /// <summary>
        /// Select menu item command
        /// </summary>
        public ICommand SelectMenuItemCommand => new DelegateCommand(() =>
            Count = DishMenu.Count(i => i.IsSelected));

        private int _count;

        /// <summary>
        /// Count of selected menu item
        /// </summary>
        public int Count
        {
            get => _count;
            set
            {
                _count = value;
                RaisePropertyChanged(nameof(Count));
            }
        }

        private Restaurant _restaurant;

        /// <summary>
        /// Restaurant data
        /// </summary>
        public Restaurant Restaurant
        {
            get => _restaurant;
            set
            {
                _restaurant = value;
                RaisePropertyChanged(nameof(Restaurant));
            }
        }

        private List<DishMenuItemViewModel> _dishMenu;

        /// <summary>
        /// List of Dish menu item
        /// </summary>
        public List<DishMenuItemViewModel> DishMenu
        {
            get => _dishMenu;
            set
            {
                _dishMenu = value;
                RaisePropertyChanged(nameof(DishMenu));
            }
        }

        /// <summary>
        /// Load Restaurant data
        /// </summary>
        private void LoadRestaurant()
        {
            Restaurant = new Restaurant()
            {
                Name = "Crazy大象",
                Address = "江苏省苏州市苏州工业园区南施街101号",
                Telephone = "13913913924 / 17323487321",
            };
        }

        /// <summary>
        /// Load Dish menu
        /// </summary>
        private void LoadDishMenu()
        {
            IDataService ds = new XmlDataService();
            var dishes = ds.GetAllDishes();
            DishMenu = dishes.Select(dish => new DishMenuItemViewModel() 
                { Dish = dish }).ToList();
        }
    }
}