using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Models
{
    public class GetPackageDBSettings:IGetPackageDBSettings
    {
        //public GetPackageDBSettings(string connectionString, string databaseName, string clientCollectionName, string driverCollectionName, string driveCollectionName, string packageCollectionName)
        //{
        //    ConnectionString = connectionString;
        //    DatabaseName = databaseName;
        //    ClientCollectionName = clientCollectionName;
        //    DriverCollectionName = driverCollectionName;
        //    DriveCollectionName = driveCollectionName;
        //    PackageCollectionName = packageCollectionName;
        //}

        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string ClientCollectionName { get; set; } = string.Empty;
        public string DriverCollectionName { get; set; } = string.Empty;
        public string DriveCollectionName { get; set; } = string.Empty;
        public string PackageCollectionName { get; set; } = string.Empty;
        public string DriveHistoryCollectionName { get; set; } = string.Empty;
        public string PackageHistoryCollectionName { get; set; } = string.Empty;
    }
}
