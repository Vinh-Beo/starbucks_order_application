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
                    DisplDeleteAll?.Invoke();
                }));
            }
        }

        //public ICommand LoadCartCommand
        //{
        //    get
        //    {
        //        return new RelayCommand(new Action(() =>
        //        {
        //            Items = new ObservableCollection<OrderItemModel>()
        //            {
        //                new OrderItemModel()
        //                {
        //                    Info = new MenuItemModel()
        //                    {
        //                        Image = "chocolate_frappuccino.png",
        //                        Name = "Chocolate Frappuccino",
        //                        Price = "30",
        //                        IsFavorite = true,
        //                        Type = TypeEnum.Chocolate,
        //                        Size = SizeEnum.Small,
        //                        Description = "Rich mocha-flavored sauce meets up with chocolaty chips, milk and ice for a blender bash. Top it off with sweetened whipped cream and mocha drizzle for a real party in your mouth.",
        //                        Rating = 5,
        //                    },
        //                    Cnt = 1,
        //                    Size = SizeEnum.Large,
        //                    OrderNumber = 2,
        //                    IsLoadImage = true,
        //                },
        //                new OrderItemModel()
        //                {
        //                    Info = new MenuItemModel
        //                    {
        //                    Image = "tea_frappuccino.png",
        //                    Name = "Tea Frappuccino",
        //                    Price = "20",
        //                    IsFavorite = false,
        //                    Type = TypeEnum.Tea,
        //                    Size = SizeEnum.Small,
        //                    Description = "This blend of sweetened premium matcha green tea, milk and ice—topped off with sweetened whipped cream—inspires a delicious boost and good green vibes.",
        //                    Rating = 4.5,
        //                    },
        //                    Cnt = 2,
        //                    Size = SizeEnum.Medium,
        //                    OrderNumber = 5,
        //                    IsLoadImage = true,
        //                },
        //                new OrderItemModel()
        //                {
        //                    Info = new MenuItemModel()
        //                    {
        //                        Image = "coffee_frappuccino.png",
        //                        Name = "Coffee Frappuccino",
        //                        Price = "10",
        //                        IsFavorite = true,
        //                        Type = TypeEnum.Coffee,
        //                        Size = SizeEnum.Small,
        //                        Description = "Coffee meets milk and ice in a blender for a rumble-and-tumble togetherness to create one of our most-beloved original Frappuccino® blended beverages.",
        //                        Rating = 4.7,
        //                    },
        //                    Cnt = 3,
        //                    OrderNumber = 10,
        //                    Size = SizeEnum.Small,
        //                    IsLoadImage = true,
        //                }
        //            };
        //            double _totalPrice = 0;
        //            foreach (OrderItemModel item in Items)
        //            {
        //                double _sizeScale = 0;
        //                if (item.Size == SizeEnum.Small)
        //                {
        //                    _sizeScale = 1;
        //                }
        //                else if (item.Size == SizeEnum.Medium)
        //                {
        //                    _sizeScale = 1.8;
        //                }
        //                else if (item.Size == SizeEnum.Large)
        //                {
        //                    _sizeScale = 2;
        //                }
        //                else
        //                {
        //                    continue;
        //                }
        //                _totalPrice  += Convert.ToDouble(item.Info.Price) * _sizeScale * item.OrderNumber;

        //                #region Register action
        //                item.DisplAdd = new Action(() =>
        //                {
        //                    item.OrderNumber += 1;
        //                });
        //                item.DisplDelete = new Action(() =>
        //                {
        //                    Items.Remove(item);
        //                });
        //                item.DisplSubtract = new Action(() =>
        //                {
        //                    item.OrderNumber -= 1;
        //                    if (item.OrderNumber <= 0)
        //                    {
        //                        Items.Remove(item);
        //                    }
        //                });
        //                #endregion
        //            }
        //            TotalPrice = _totalPrice.ToString();
        //        }));
        //    }
        //}
    }
}
