using ShoppoingAppTask.Base;
using ShoppoingAppTask.Helpers;
using ShoppoingAppTask.Model;
using ShoppoingAppTask.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppoingAppTask.Pages
{
    public partial class OrdersPageXaml : BaseContentPage<OrdersViewModel>
    {
    }
    public partial class OrdersPage : OrdersPageXaml
    {
        public OrdersPage()
        {
            InitializeComponent();
            this.ToolbarItems.Add(new ToolbarItem()
            {
                Text = "Add",
                IconImageSource = "add.png",
                Command = new Command(() =>
                {
                    var page = new AddNewOrder();
                    this.Navigation.PushModalAsync(new NavigationPage(page));
                })
            });
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.Orders.Clear();
            ViewModel.IsBusy = true;
            var list = await App.Database.GetOrdersAsync();
            ViewModel.IsBusy = false;
            ViewModel.Orders.AddRange(list.Select(r => new OrdersDto(r.OrderID, r.OrderDate, r.OrderAmount, r.ClientDescription)));
            ViewModel.HasData = ViewModel.Orders.Any();
        }
        private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is OrdersDto order)
            {
                var page = new OrderDefinitionPage(order);
                await this.Navigation.PushOnceAsync(page);
            }
        }

    }
}