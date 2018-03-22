using System;
using MVVM.ViewModel;
using Xamarin.Forms;

namespace MVVM.View
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            var plvm = PhoneListViewModel.GetPhoneViewModel(this.Navigation);
            var phonesListView = new ListView
            {
                ItemsSource = plvm.Phones,
                ItemTemplate = new DataTemplate(() => 
                {
                    Label titleLabel = new Label { FontSize = 18 };
                    titleLabel.SetBinding(Label.TextProperty, "Model");

                    // привязка к свойству Company
                    Label companyLabel = new Label();
                    companyLabel.SetBinding(Label.TextProperty, "Company");


                    // привязка к свойству Price
                    Label priceLabel = new Label();
                    priceLabel.SetBinding(Label.TextProperty, "Price");

                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Horizontal,
                            Children = { titleLabel, companyLabel, priceLabel }
                        }
                    };
                })
            };



            var addBtn = new Button
            {
                Text = "  Add new phone  ",
                BorderWidth = 1

            };
            addBtn.Clicked += async (sender, e) => 
            {
                await Navigation.PushModalAsync(new PhonePage());
            };

            var contentLayout = new StackLayout
            {
            };
            contentLayout.Children.Add(addBtn);
            contentLayout.Children.Add(phonesListView);

            Content = contentLayout;
        }
    }
}

