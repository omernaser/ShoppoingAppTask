using ShoppoingAppTask.Data;
using ShoppoingAppTask.Pages;
using ShoppoingAppTask.Resources;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppoingAppTask
{
    public partial class App : Application
    {
        static OrdersDataBase database;

        // Create the database connection as a singleton.
        public static OrdersDataBase Database
        {
            get
            {
                if (database == null)
                {
                    database = new OrdersDataBase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Orders.db3"));
                }
                return database;
            }
        }
        public App()
        {
            Localization.Init();
            InitializeComponent();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
