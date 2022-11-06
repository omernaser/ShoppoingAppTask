using ShoppoingAppTask.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppoingAppTask.ViewModels
{
    public class OrderDefinitionViewModel : Base.BaseViewModel
    {
        private OrdersDto orderItem;
        private string newClientDescription;

        public Model.OrdersDto OrderItem { get => orderItem; set => SetProperty(ref orderItem, value); }

        public string NewClientDescription { get => newClientDescription; set =>SetProperty(ref newClientDescription , value); }
    }
}
