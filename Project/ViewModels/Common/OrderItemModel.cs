using Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Project.ViewModels.Common
{
    public class OrderItemModel : ViewModelBase
    {
        private int _Cnt;
        public int Cnt { get => _Cnt; set { _Cnt = value; OnPropertyChanged("Cnt"); } }
        private MenuItemModel _Info;
        public MenuItemModel Info { get => _Info; set { _Info = value; OnPropertyChanged("Info"); } }

        private int _OrderNumber;
        public int OrderNumber { get => _OrderNumber; set { _OrderNumber = value; OnPropertyChanged("OrderNumber"); } }

        private SizeEnum _Size;
        public SizeEnum Size { get => _Size; set { _Size = value; OnPropertyChanged("Size"); } }

        private bool _IsLoadImage;
        public bool IsLoadImage { get => _IsLoadImage; set { _IsLoadImage = value; OnPropertyChanged("IsLoadImage"); } }

        public Action DisplDelete;
        public ICommand DeleteCommand
        {
            get
            {
                return new RelayCommand(new Action(() =>
                {
                    DisplDelete?.Invoke();
                }));
            }
        }

        public Action DisplAdd;
        public ICommand AddCommand
        {
            get
            {
                return new RelayCommand(new Action(() =>
                {
                    DisplAdd?.Invoke();
                }));
            }
        }

        public Action DisplSubtract;
        public ICommand SubTractCommand
        {
            get
            {
                return new RelayCommand(new Action(() =>
                {
                    DisplSubtract?.Invoke();
                }));
            }
        }
    }
}
