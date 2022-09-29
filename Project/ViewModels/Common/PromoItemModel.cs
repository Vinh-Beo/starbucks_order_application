using Common;
using System;
using System.Windows.Input;

namespace Project.ViewModels.Common
{
    public class PromoItemModel: ViewModelBase
    {
        private bool _IsNew;
        public bool IsNew { get => _IsNew; set { _IsNew = value; OnPropertyChanged("IsNew"); } }
        private string _Image;
        public string Image { get => _Image; set { _Image = value; OnPropertyChanged("Image"); } }

        private TypeEnum _Type;
        public TypeEnum Type { get => _Type; set { _Type = value; OnPropertyChanged("Type"); } }

        private string _Code;
        public string Code { get => _Code; set { _Code = value; OnPropertyChanged("Code"); } }

        private double _Discount;
        public double Discount { get => _Discount; set { _Discount = value; OnPropertyChanged("Discount"); } }

        public ICommand CopyCommand
        {
            get
            {
                return new RelayCommand(new Action(() =>
                {
                    
                }));
            }
        }
    }
}
