using ShoppoingAppTask.Base;
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
    public partial class OrderDefinitionPageXaml : BaseContentPage<OrderDefinitionViewModel>
    {
    }
    public partial class OrderDefinitionPage : OrderDefinitionPageXaml
    {
        public OrderDefinitionPage(Model.OrdersDto order)
        {
            InitializeComponent();
            ViewModel.OrderItem = order;
        }



        private async void Edit_Clicked(object sender, EventArgs e)
        {
            await App.Database.SaveOrderseAsync(new Model.OrdersDBModel(ViewModel.OrderItem.OrderID, ViewModel.OrderItem.OrderDate, ViewModel.OrderItem.OrderAmount, ViewModel.NewClientDescription));
            await this.Navigation.PopAsync();
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            await App.Database.DeleteOrdersAsync(new Model.OrdersDBModel(ViewModel.OrderItem.OrderID, ViewModel.OrderItem.OrderDate, ViewModel.OrderItem.OrderAmount, ViewModel.OrderItem.ClientDescription));
            await this.Navigation.PopAsync();
        }
    }
}