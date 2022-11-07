using ShoppoingAppTask.Base;
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
    public partial class AddNewOrderXaml : BaseContentPage<AddNewOrderViewModel>
    {
    }
    public partial class AddNewOrder : AddNewOrderXaml
    {
        public AddNewOrder()
        {
            InitializeComponent();
            ToolbarItems.Add(new ToolbarItem()
            {
                Text = "Cancel",
                Command = new Command(async () =>
                {
                    await this.Navigation.PopModalAsync();
                })
            });
        }

        private void Search_Button_Clicked(object sender, EventArgs e)
        {
            ViewModel.SearchClicked = true;
        }



        private void AddQuantity_Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.BindingContext is OrdersDto order)
                order.Quantity++;
        }

        private void RemoveQuantity_Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.BindingContext is OrdersDto order)
                order.Quantity--;
        }

        private async void Submit_Button_Clicked(object sender, EventArgs e)
        {
            if (ViewModel.Orders.Select(r => r.Quantity).Any(r => r > 0))
            {
                var list = ViewModel.Orders.Select(r => new OrdersDBModel(r.OrderID, r.OrderDate, r.OrderAmount, r.ClientDescription));
                foreach (var item in list)
                {
                    await App.Database.SaveOrderseAsync(item);
                }
                await this.Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("No Items Selected", "Please select Some Items To Complete your Order", "Cancel");
            }
        }
    }
}