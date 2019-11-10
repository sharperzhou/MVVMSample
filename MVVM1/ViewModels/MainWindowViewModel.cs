using System;
using System.Globalization;
using System.Windows;
using System.Windows.Input;
using MVVM1.Commands;

namespace MVVM1.ViewModels
{
    public class MainWindowViewModel : NotificationObject
    {
        private double _input1;

        /// <summary>
        /// Input1
        /// </summary>
        public double Input1
        {
            get => _input1;
            set
            {
                _input1 = value;
                OnPropertyChanged(nameof(Input1));
            }
        }

        private double _input2;

        /// <summary>
        /// Input2
        /// </summary>
        public double Input2
        {
            get => _input2;
            set
            {
                _input2 = value;
                OnPropertyChanged(nameof(Input2));
            }
        }

        private double _result;

        /// <summary>
        /// Result
        /// </summary>
        public double Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        public ICommand CalcCommand => new DelegateCommand(
            param => Result = Input1 + Input2);

        public ICommand SaveCommand => new DelegateCommand(
            param => MessageBox.Show("保存成功！"));
    }
}