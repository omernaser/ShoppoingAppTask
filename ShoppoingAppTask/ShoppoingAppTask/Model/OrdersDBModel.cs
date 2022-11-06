using ShoppoingAppTask.Helpers;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppoingAppTask.Model
{
    public class OrdersDBModel
    {
        [PrimaryKey, AutoIncrement]
        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; }
        public double OrderAmount { get; set; }
        public string ClientDescription { get; set; }
        public int Quantity { get; set; }
        public string UserName { get; set; }
        public OrdersDBModel()
        {

        }
        public OrdersDBModel(int orderId, DateTime orderDate, double orderAmount, string clientDescription)
        {
            OrderID = orderId;
            OrderDate = orderDate;
            OrderAmount = orderAmount;
            ClientDescription = clientDescription;
            UserName = Settings.GetString(Constants.UserNameKey);
        }
    }
}
