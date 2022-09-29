using Common;
using Project.ViewModels.Common;
using Project.ViewModels.Main.Detail;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Project.ViewModels.Main.Cart
{
    public class CartViewModel:ViewModelBase
    {
        private string _TotalPrice;
        public string TotalPrice { get => _TotalPrice; set { _TotalPrice = value; OnPropertyChanged("TotalPrice"); } }

        private ObservableCollection<OrderItemModel> _Items;
        public ObservableCollection<OrderItemModel> Items { get => _Items; set { _Items = value; OnPropertyChanged("Items"); } }

        public Action DisplBack;
        public ICommand BackCommand
        {
            get
            {
                return new RelayCommand(new Action(() =>
                {
                    DisplBack?.Invoke();
                }));
            }
        }

        public Action DisplDeleteAll;
        public ICommand DeleteAllCommand
        {
            get
            {
                return new RelayCommand(new Action(() =>
                {
                    TotalPrice = "0";
                    DisplDeleteAll?.Invoke();
                }));
            }
        }

        public ICommand TotalPriceCommand
        {
            get
            {
                return new RelayCommand(new Action(() =>
                {
                    double _totalPrice = 0;
                    foreach (OrderItemModel item in Items)
                    {
                        double _sizeScale = 0;
                        if (item.Size == SizeEnum.Small)
                        {
                            _sizeScale = 1;
                        }
                        else if (item.Size == SizeEnum.Medium)
                        {
                            _sizeScale = 1.8;
                        }
                        else if (item.Size == SizeEnum.Large)
                        {
                            _sizeScale = 2;
                        }
                        else
                        {
                            continue;
                        }
                        _totalPrice += Convert.ToDouble(item.Info.Price) * _sizeScale * item.OrderNumber;
                    }
                    TotalPrice = _totalPrice.ToString();
                }));
            }
        }
    }
}
