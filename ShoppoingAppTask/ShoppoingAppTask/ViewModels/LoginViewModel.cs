using ShoppoingAppTask.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppoingAppTask.ViewModels
{
    public class LoginViewModel : Base.BaseViewModel
    {
        private string laguage = Constants.CurrentAppLaguage;
        private string userName;
        private string password;

        public string Laguage { get => laguage; set => SetProperty(ref laguage, value); }
        public string UserName { get => userName; set => SetProperty(ref userName, value); }
        public string Password { get => password; set =>SetProperty(ref password , value) ; }
    }
}
