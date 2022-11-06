using ShoppoingAppTask.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppoingAppTask.Data
{
    public class OrdersDataBase
    {
        readonly SQLiteAsyncConnection database;
        public OrdersDataBase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<OrdersDBModel>().Wait();
        }
        public Task<List<OrdersDBModel>> GetOrdersAsync()
        {
            //Get all Order.
            return database.Table<OrdersDBModel>().ToListAsync();
        }
        public Task<OrdersDBModel> GetOrdersAsync(int id)
        {
            // Get a specific Order.
            return database.Table<OrdersDBModel>()
                            .Where(i => i.OrderID == id)
                            .FirstOrDefaultAsync();
        }
        public Task<int> SaveOrderseAsync(OrdersDBModel order)
        {
            if (order.OrderID != 0)
            {
                // Update an existing Order.
                return database.UpdateAsync(order);
            }
            else
            {
                // Save a new Order.
                return database.InsertAsync(order);
            }
        }
        public Task<int> DeleteOrdersAsync(OrdersDBModel order)
        {
            // Delete a Order.
            return database.DeleteAsync(order);
        }
    }
}
