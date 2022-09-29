using Common;
using Project.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Project.ViewModels.Main.Detail
{
    public class DetailViewModel:ViewModelBase
    {
        private MenuItemModel _Info;
        public MenuItemModel Info { get => _Info; set { _Info = value; OnPropertyChanged("Info"); } }

        private int _OrderNumber;
        public int OrderNumber { get => _OrderNumber; set { _OrderNumber = value; OnPropertyChanged("OrderNumber"); } }

        private ObservableCollection<DetailSizeModel> _Sizes;
        public ObservableCollection<DetailSizeModel> Sizes { get => _Sizes; set { _Sizes = value; OnPropertyChanged("Sizes"); } }

        private DetailSizeModel _SizeItem;
        public DetailSizeModel SizeItem { get => _SizeItem; set { _SizeItem = value; OnPropertyChanged("SizeItem"); } }

        private OrderItemModel _Order;
        public OrderItemModel Order { get => _Order; set { _Order = value; OnPropertyChanged("Order"); } }

        private bool _IsDetail;
        public bool IsDetail { get => _IsDetail; set { _IsDetail = value; OnPropertyChanged("IsDetail"); } }

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

        public ICommand AddToFavoriteCommand
        {
            get
            {
                return new RelayCommand(new Action(() =>
                {
                    Info.IsFavorite = !Info.IsFavorite;
                }));
            }
        }

        public Action<OrderItemModel> DisplOrder;
        public ICommand AddToCartCommand
        {
            get
            {
                return new RelayCommand(new Action(() =>
                {
                    if (OrderNumber <= 0)
                    {
                        return;
                    }
                    Order = new OrderItemModel()
                    {
                        Cnt = 1,
                        Info = Info,
                        Size = SizeItem.Size,
                        OrderNumber = OrderNumber,
                        IsLoadImage = true,
                    };
                    DisplOrder?.Invoke(Order);
                }));
            }
        }
    }
}
