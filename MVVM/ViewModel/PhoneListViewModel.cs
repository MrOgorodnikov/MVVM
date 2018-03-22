using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace MVVM.ViewModel
{

    public static class ObjectExtention
    {
        public static object ToType<T>(this object obj, T type)
        {
            //create instance of T type object:
            object tmp = Activator.CreateInstance(Type.GetType(type.ToString()));

            //loop through the properties of the object you want to covert:          
            foreach (PropertyInfo pi in obj.GetType().GetProperties())
            {
                try
                {
                    //get the value of property and try to assign it to the property of T type object:
                    tmp.GetType().GetProperty(pi.Name).SetValue(tmp, pi.GetValue(obj, null), null);
                }
                catch (Exception ex)
                {
                    //Logging.Log.Error(ex);
                }
            }
            //return the T type object:         
            return tmp;
        }
    }

    public class PhoneListViewModel: INotifyPropertyChanged
    {
        public ICommand CreatePhoneCommand { protected set; get; }
        public ICommand RemovePhoneCommand { protected set; get; }
        public ICommand EditPhoneCommand { protected set; get; }
        public ICommand SavePhoneCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }

        public INavigation Navigation { get; set; }

        private PhoneListViewModel(INavigation n)
        {
            Navigation = n;
            Phones = new ObservableCollection<PhoneViewModel>();
            RemovePhoneCommand = new Command(RemovePhone);
            EditPhoneCommand = new Command(EditPhone);
            SavePhoneCommand = new Command(SavePhone);
            BackCommand = new Command(Back);
        }

        private static PhoneListViewModel ListViewModel;

        public static PhoneListViewModel GetPhoneViewModel(INavigation n)
        {
            if (ListViewModel == null)
            {
                ListViewModel = new PhoneListViewModel(n);
            }

            return ListViewModel;
        }

        public ObservableCollection<PhoneViewModel> Phones { get; set; } 
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private async void Back()
        {
            await Navigation.PopModalAsync();
        }

        private class PhoneEntry{
            public Entry Company { get; set; }
            public Entry Model { get; set; }
            public Entry Price { get; set; }
        }

        private void SavePhone(object phone)
        {
            //var x = (PhoneEntry)phone.ToType(new PhoneEntry());
            //var c = x.Company.Text;
            //var m = x.Model.Text;
            //var pr = Convert.ToDecimal(x.Price.Text);

            //var p = new PhoneViewModel
            //{
            //    Company = c,
            //    Model = m,
            //    Price = pr
            //};

            var p = phone as PhoneViewModel;
            if(p != null)
            {
                Phones.Add(p);
            }

            Back();
        }

        private void RemovePhone(object phone)
        {
            var p = phone as PhoneViewModel;

            var phoneToRemove = Phones.FirstOrDefault(ph => ph.Id == p.Id);

            Phones.Remove(phoneToRemove);

            Back();
        }

        private void EditPhone(object phone)
        {
            var p = phone as PhoneViewModel;
            var editedPhone = Phones.FirstOrDefault(ph => ph.Id == p.Id);

            if(editedPhone != null)
            {
                editedPhone.Model = p.Model;
                editedPhone.Price = p.Price;
                editedPhone.Company = p.Company;
            }
        }
    }
}
