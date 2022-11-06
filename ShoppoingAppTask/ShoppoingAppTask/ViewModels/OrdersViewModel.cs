using MvvmHelpers;
using ShoppoingAppTask.Helpers;
using ShoppoingAppTask.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppoingAppTask.ViewModels
{
    public class OrdersViewModel : Base.BaseViewModel
    {
        private bool hasData;
        private bool hasMoreItems;

        public ObservableRangeCollection<OrdersDto> Orders { get; } = new ObservableRangeCollection<OrdersDto>();
        public bool HasData { get => hasData; set => SetProperty(ref hasData, value); }
        public bool HasMoreItems { get => hasMoreItems; set => SetProperty(ref hasMoreItems, value); }
        public OrdersViewModel()
        {
            
        }

    }
}
