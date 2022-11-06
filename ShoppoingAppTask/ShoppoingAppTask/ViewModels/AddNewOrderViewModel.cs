using MvvmHelpers;
using ShoppoingAppTask.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppoingAppTask.ViewModels
{
    public class AddNewOrderViewModel : Base.BaseViewModel
    {
        private DateTime selectedDate;
        private string selectedClient;
        private bool searchClicked;

        public DateTime SelectedDate { get => selectedDate; set => SetProperty(ref selectedDate, value); }

        public string SelectedClient
        {
            get => selectedClient; set
            {
                SetProperty(ref selectedClient, value);
                if (!string.IsNullOrEmpty(value))
                {
                    Orders.Clear();
                    for (int i = 0; i < 3; i++)
                    {
                        Orders.Add(new OrdersDto(i, DateTime.Now, 5.6 + i, selectedClient));
                    }
                }
              
            }
        }
        public ObservableRangeCollection<OrdersDto> Orders { get; } = new ObservableRangeCollection<OrdersDto>();

        public bool SearchClicked { get => searchClicked; set =>SetProperty(ref searchClicked , value) ; }
        public AddNewOrderViewModel()
        {
            for (int i = 0; i < 3; i++)
            {
                Orders.Add(new OrdersDto(i, DateTime.Now, 5.6 + i, "Omar Test Omar Test Omar Test Omar Test Omar Test Omar Test Omar Test"));
            }
        }
    }
}
