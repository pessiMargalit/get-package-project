
namespace Dal
{
    public interface IDataContext
    {
        IMongoCollection<Client> ClientCollection { get; }
        IMongoCollection<Drive> DriveCollection { get; }
        IMongoCollection<Driver> DriverCollection { get; }
        IMongoCollection<Package> PackageCollection { get; }
        IMongoCollection<DriveHistory> DriveHistoryCollection { get; }
        IMongoCollection<PackageHistory> PackageHistoryCollection { get; }
    }
}