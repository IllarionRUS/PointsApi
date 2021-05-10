#region snippet_OrderServiceClass
using PointsApiMongoDB.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text.RegularExpressions;

namespace PointsApiMongoDB.Services
{
    public class OrderService
    {
        private readonly IMongoCollection<Order> _orders;

        #region snippet_OrderServiceConstructor
        public OrderService(IOrderstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _orders = database.GetCollection<Order>(settings.OrdersCollectionName);
        }
        #endregion

        public List<Order> Get() =>
            _orders.Find(order => true).ToList();

        public Order Get(int id) =>
            _orders.Find<Order>(order => order.Id == id).FirstOrDefault();

        public Order Create(Order order)
        {
            return order;
        }

        public void Update(int id, Order orderIn) =>
            _orders.ReplaceOne(order => order.Id == id, orderIn);

        public void Remove(Order orderIn) =>
            _orders.DeleteOne(order => order.Id == orderIn.Id);

        public void Remove(int id) =>
            _orders.DeleteOne(order => order.Id == id);


    }
}
#endregion
