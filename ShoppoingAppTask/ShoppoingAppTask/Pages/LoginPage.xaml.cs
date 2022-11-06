using ShoppoingAppTask.Base;
using ShoppoingAppTask.Helpers;
using ShoppoingAppTask.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static SQLite.SQLite3;

namespace ShoppoingAppTask.Pages
{
    public partial class LoginPageXaml : BaseContentPage<LoginViewModel>
    {
    }
    public partial class LoginPage : LoginPageXaml
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Settings.SetString(Constants.UserNameKey, ViewModel.UserName);
            App.Current.MainPage = new NavigationPage(new OrdersPage());
        }

        private async void Laguage_Tapped(object sender, EventArgs e)
        {
            var result = await DisplayActionSheet("Change App Laguage", "Cancel", null, new List<string>() { "ar", "en" }.ToArray());
            if (result != null && result != "Cancel")
            {
                Settings.SetString(Constants.AppLaguageKey, result);
                ViewModel.Laguage = result;
                Device.BeginInvokeOnMainThread(() => { App.Current.MainPage = new LoginPage(); }); 
            }
        }
    }
}