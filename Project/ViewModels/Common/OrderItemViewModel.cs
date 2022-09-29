using System;
namespace Common
{
    public class OrderItemViewModel : ViewModelBase
    {
        private long _Id;
        public long Id { get => _Id; set { _Id = value; OnPropertyChanged("Id"); } }

        private string _Code;
        public string Code { get => _Code; set { _Code = value; OnPropertyChanged("Code"); } }

        private bool _IsFinish;
        public bool IsFinish { get => _IsFinish; set { _IsFinish = value; OnPropertyChanged("IsFinish"); } }

        private DateTime _Time;
        public DateTime Time { get => _Time; set { _Time = value; OnPropertyChanged("Time"); } }

        private double _Litre;
        public double Litre { get => _Litre; set { _Litre = value; OnPropertyChanged("Litre"); } }

        private double _Money;
        public double Money { get => _Money; set { _Money = value; OnPropertyChanged("Money"); } }

        private string _MoneyCode;
        public string MoneyCode { get => _MoneyCode; set { _MoneyCode = value; OnPropertyChanged("MoneyCode"); } }
    }
}
