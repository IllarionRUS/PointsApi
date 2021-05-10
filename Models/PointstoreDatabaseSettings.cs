namespace PointsApiMongoDB.Models
{
    public class PointstoreDatabaseSettings : IPointstoreDatabaseSettings
    {
        public string PointsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IPointstoreDatabaseSettings
    {
        string PointsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
