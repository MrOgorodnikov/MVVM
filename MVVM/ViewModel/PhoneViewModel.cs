using System;
using System.ComponentModel;
using MVVM.Model;

namespace MVVM.ViewModel
{
    public class PhoneViewModel : INotifyPropertyChanged
    {
        public PhoneViewModel()
        {
        }

        private Phone Phone = new Phone();

        public int Id
        {
            get
            {
                return Phone.Id;
            }
            set
            {
                if(value != Phone.Id && value > 0)
                {
                    Phone.Id = value;
                    OnPropertyChanged("Phone");
                };
            }
        }

        public string Company
        {
            get
            {
                return Phone.Company;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && value != Phone.Company)
                {
                    Phone.Company = value;
                    OnPropertyChanged("Company");
                }
            }
        }

        public string Model
        {
            get
            {
                return Phone.Model;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && value != Phone.Model)
                {
                    Phone.Model = value;
                    OnPropertyChanged("Model");
                }
            }
        }

        public decimal Price
        {
            get
            {
                return Phone.Price;
            }
            set
            {
                if(value > 0 && value != Phone.Price)
                {
                    Phone.Price = value;
                    OnPropertyChanged("Price");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
