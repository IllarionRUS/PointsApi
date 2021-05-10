using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
#region snippet_NewtonsoftJsonImport
using Newtonsoft.Json;
#endregion

namespace PointsApiMongoDB.Models
{
    public class Point
    {
        private static Point instance;

        private Point()
        { }

        public static Point getInstance()
        {
            if (instance == null)
                instance = new Point();
            return instance;
        }

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }

    }
}
