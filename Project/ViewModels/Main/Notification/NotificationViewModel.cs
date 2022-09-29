using Common;
using Project.Language;
using Project.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModels.Main.Notification
{
    public class NotificationViewModel: ViewModelBase
    {
        private UserModel _User;
        public UserModel User { get => _User; set { _User = value; OnPropertyChanged("User"); } }

        private ObservableCollection<TypeEnumModel> _Types = new ObservableCollection<TypeEnumModel>();
        public ObservableCollection<TypeEnumModel> Types { get => _Types; set { _Types = value; OnPropertyChanged("Types"); } }

        private ObservableCollection<PromoItemModel> _Promos;
        public ObservableCollection<PromoItemModel> Promos { get => _Promos; set { _Promos = value; OnPropertyChanged("Promos"); } }

        private ObservableCollection<PromoItemModel> _ClonePromos;
        public ObservableCollection<PromoItemModel> ClonePromos { get => _ClonePromos; set { _ClonePromos = value; OnPropertyChanged("ClonePromos"); } }

        public ICommand LoadPromosCommand
        {
            get
            {
                return new RelayCommand(new Action(() =>
                {
                    Promos = new ObservableCollection<PromoItemModel>()
                    {
                        new PromoItemModel()
                        {
                            Code = "HeVe",
                            Type = TypeEnum.Coffee,
                            Image = "Discount.jpg",
                            Discount = 10,
                            IsNew = false,
                        },
                        new PromoItemModel()
                        {
                            Code = "ToiYeuCoffee",
                            Type = TypeEnum.Coffee,
                            Image = "Discount5.jpg",
                            Discount = 5,
                            IsNew = true,
                        },
                        new PromoItemModel()
                        {
                            Code = "ToiYeuTea",
                            Type = TypeEnum.Tea,
                            Image = "Discount4.jpg",
                            Discount = 7,
                            IsNew = true,
                        },
                        new PromoItemModel()
                        {
                            Code = "ToiYeuChocolate",
                            Type = TypeEnum.Chocolate,
                            Image = "Discount2.jpg",
                            Discount = 8,
                            IsNew = true,
                        },
                        new PromoItemModel()
                        {
                            Code = "DonNamHocMoi",
                            Type = TypeEnum.Coffee,
                            Image = "Discount1.jpg",
                            Discount = 15,
                            IsNew = false,
                        },
                        new PromoItemModel()
                        {
                            Code = "KhangHangMoi",
                            Type = TypeEnum.Chocolate,
                            Image = "Discount6.jpg",
                            Discount = 30,
                            IsNew = false,
                        },
                        new PromoItemModel()
                        {
                            Code = "Weekend",
                            Type = TypeEnum.Tea,
                            Image = "Discount7.jpg",
                            Discount = 12,
                            IsNew = true,
                        },
                    };
                    //promosList.OrderBy(x => x).ToList();
                    Promos = new ObservableCollection<PromoItemModel>(Promos.OrderByDescending(p => p.IsNew == true));
                    ClonePromos = new ObservableCollection<PromoItemModel>(Promos);
                }));
            }
        }

        public NotificationViewModel()
        {

        }
    }
}
