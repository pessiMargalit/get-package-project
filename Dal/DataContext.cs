
namespace Dal
{
    public class DataContext : IDataContext
    {
        private readonly IMongoDatabase db;
        public IMongoCollection<Client> ClientCollection { get; }
        public IMongoCollection<Driver> DriverCollection { get; }
        public IMongoCollection<Drive> DriveCollection { get; }
        public IMongoCollection<Package> PackageCollection { get; }
        public IMongoCollection<DriveHistory> DriveHistoryCollection { get; }
        public IMongoCollection<PackageHistory> PackageHistoryCollection { get; }

        public DataContext(IGetPackageDBSettings settings)
        {
            MongoClient dbClient = new MongoClient(settings.ConnectionString);
            db = dbClient.GetDatabase(settings.DatabaseName);
            ClientCollection = db.GetCollection<Client>(settings.ClientCollectionName);
            DriverCollection = db.GetCollection<Driver>(settings.DriverCollectionName);
            DriveCollection = db.GetCollection<Drive>(settings.DriveCollectionName);
            PackageCollection = db.GetCollection<Package>(settings.PackageCollectionName);
            DriveHistoryCollection = db.GetCollection<DriveHistory>(settings.DriveHistoryCollectionName);
            PackageHistoryCollection = db.GetCollection<PackageHistory>(settings.PackageHistoryCollectionName);
        }
        //public DataContext()
        //{
        //    MongoClient dbClient = new MongoClient("mongodb+srv://finalProject:41214121@getpackage.km4sihj.mongodb.net/?retryWrites=true&w=majority");
        //    db = dbClient.GetDatabase("getPackage");
        //    ClientCollection = db.GetCollection<Client>("clients");
        //    DriverCollection = db.GetCollection<Driver>("drivers");
        //    DriveCollection = db.GetCollection<Drive>("drives");
        //    PackageCollection = db.GetCollection<Package>("packages");
        //}




    }
}
