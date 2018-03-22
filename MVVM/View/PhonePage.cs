using System;

using Xamarin.Forms;

namespace MVVM.View
{
    public class PhonePage : ContentPage
    {
        public PhonePage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

