#region snippet_PointServiceClass
using PointsApiMongoDB.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace PointsApiMongoDB.Services
{
    public class PointService
    {
        private readonly IMongoCollection<Point> _points;

        #region snippet_PointServiceConstructor
        public PointService(IPointstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _points = database.GetCollection<Point>(settings.PointsCollectionName);
        }
        #endregion

        public List<Point> Get() =>
            _points.Find(point => true).ToList();

        public Point Get(string id) =>
            _points.Find<Point>(point => point.Id == id).FirstOrDefault();


    }
}
#endregion
