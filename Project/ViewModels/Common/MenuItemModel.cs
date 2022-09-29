using Common;
using Project.ViewModels.Main.Detail;
using Project.Views.Main.Detail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Project.ViewModels.Common
{
    public class MenuItemModel: ViewModelBase
    {
        private string _Image;
        public string Image { get => _Image; set { _Image = value; OnPropertyChanged("Image"); } }
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged("Name"); } }
        private string _Price;
        public string Price { get => _Price; set { _Price = value; OnPropertyChanged("Price"); } }
        private bool _IsFavorite;
        public bool IsFavorite { get => _IsFavorite; set { _IsFavorite = value; OnPropertyChanged("IsFavorite"); } }
        private TypeEnum _Type;
        public TypeEnum Type { get => _Type; set { _Type = value; OnPropertyChanged("Type"); } }

        private string _Description;
        public string Description { get => _Description; set { _Description = value; OnPropertyChanged("Description"); } }

        private double _Rating;
        public double Rating { get => _Rating; set { _Rating = value; OnPropertyChanged("Rating"); } }

        private SizeEnum _Size;
        public SizeEnum Size { get => _Size; set { _Size = value; OnPropertyChanged("Size"); } }

        public ICommand ProductFavCommand
        {
            get
            {
                return new RelayCommand(new Action(() =>
                {
                    IsFavorite = !IsFavorite;
                }));
            }
        }
        public Action<MenuItemModel> DisplShowDetail;
        public ICommand DetailCommand
        {
            get
            {
                return new RelayParamCommand(new Action<object>((object obj) =>
                {
                    if (obj == null)
                    {
                        return;
                    }
                    if (obj.GetType() != typeof(MenuItemModel))
                    {
                        return;
                    }
                    MenuItemModel _vm = obj as MenuItemModel;
                    DisplShowDetail?.Invoke(_vm);
                }));
            }
        }
    }
    public class TypeEnumModel:ViewModelBase
    {
        private TypeEnum _Code;
        public TypeEnum Code { get => _Code; set { _Code = value; OnPropertyChanged("Code"); } }

        private bool _IsSelected;
        public bool IsSelected { get => _IsSelected; set { _IsSelected = value; OnPropertyChanged("IsSelected"); } }

        public Action DisplSel;
        public ICommand SelectedCmd
        {
            get
            {
                return new RelayCommand(new Action(() =>
                {
                    DisplSel?.Invoke();
                }));
            }
        }
    }
}
