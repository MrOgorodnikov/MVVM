using System;
using MVVM.Model;
using MVVM.ViewModel;
using Xamarin.Forms;

namespace MVVM.View
{
    public class PhonePage : ContentPage
    {
        StackLayout _contentLayout, _buttonLayout;
        Entry _modelEntry, _companyEntry, _priceEntry, _idEntry;
        Button _saveBtn, _clearAll, _backBtn;
        PhoneListViewModel plvm;
        PhoneViewModel _phone = new PhoneViewModel();
        public PhonePage()
        {
            plvm = PhoneListViewModel.GetPhoneViewModel(this.Navigation);
            _idEntry = new Entry
            {
                IsVisible = false,
                BindingContext = "Id",
                Text = "0"
            };

            _modelEntry = new Entry
            {
                Placeholder = "Model",
                Keyboard = Keyboard.Default,

            };

            _companyEntry = new Entry
            {
                Placeholder = "Company",
            };

            _priceEntry = new Entry
            {
                Placeholder="Price",
                Keyboard = Keyboard.Numeric,
                Text = "0"
            };

            _modelEntry.TextChanged += (s, e) => _phone.Model = e.NewTextValue;
            _companyEntry.TextChanged += (s, e) => _phone.Company = e.NewTextValue;
            _priceEntry.TextChanged += (s, e) => _phone.Price = Convert.ToDecimal(e.NewTextValue);




            string s1 = "866755775";
            var x = s1.ToCharArray();
            x[0] = '!';
            s1 = string.Empty;
            foreach (var ch in x) s1 += ch;




            _saveBtn = new Button
            {
                Text = "  Create  ",
                BorderWidth = 1,

                Command = plvm.SavePhoneCommand,
                //CommandParameter = new {Company = this._companyEntry, Model = this._modelEntry, Price = this._priceEntry}
                //CommandParameter = s1//_phone
                              
            };

            _saveBtn.Clicked += (s, e) =>
            {
                _saveBtn.CommandParameter = _companyEntry.Text;
            };


            _backBtn = new Button
            {
                Text = "  Back  ",
                BorderWidth = 1,
                Command = plvm.BackCommand,

            };

            _buttonLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,

            };
            _buttonLayout.Children.Add(_backBtn);
            _buttonLayout.Children.Add(_saveBtn);

            Thickness margin;
            if(Device.RuntimePlatform == Device.iOS){
                margin = new Thickness(0, 20, 0, 0);
            }
            else{
                margin = new Thickness(0, 0, 0, 0);
            }

            _contentLayout = new StackLayout();
            _contentLayout.Margin = margin;
            _contentLayout.Children.Add(_companyEntry);
            _contentLayout.Children.Add(_modelEntry);
            _contentLayout.Children.Add(_priceEntry);
            _contentLayout.Children.Add(_buttonLayout);

            Content = _contentLayout;
        }

        public PhonePage(PhoneViewModel phone) : this()
        {

        }

        void PriceEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}

