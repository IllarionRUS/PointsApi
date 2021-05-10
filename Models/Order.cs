using System.Collections.Generic;
using System.Text.RegularExpressions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
#region snippet_NewtonsoftJsonImport
using Newtonsoft.Json;
#endregion

namespace PointsApiMongoDB.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int Id { get; set; }
        public int Status { get; set; }
        public string[] OrderList { get; set; }
        public decimal OrderPrice { get; set; }
        public string PointNumber { get; set; }
        public string RecepientPhone { get; set; }
        public string RecepientName { get; set; }  
    }

    public class OrderStatus
    {
        Dictionary<int, string> orderstatus = new Dictionary<int, string>
        {
            [1] = "Зарегистрирован",
            [2] = "Принят на склад",
            [3] = "Выдан курьеру",
            [4] = "Доставлен в постамат",
            [5] = "Доставлен получателю"
        };
    }


}
