using ShoppoingAppTask.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppoingAppTask.Model
{
    public class OrdersDto : BaseNotifiedModel
    {
        private int quantity;

        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public double OrderAmount { get; set; }
        public string ClientDescription { get; set; }
        public int Quantity { get => quantity; set =>SetProperty(ref quantity , value) ; }
        public string UserName { get; set; }

        public OrdersDto(int orderId, DateTime orderDate, double orderAmount, string clientDescription)
        {
            OrderID = orderId;
            OrderDate = orderDate;
            OrderAmount = orderAmount;
            ClientDescription = clientDescription;

        }

    }
}
