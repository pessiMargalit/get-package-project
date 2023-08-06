using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Models
{
    public interface IGetPackageDBSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string ClientCollectionName { get; set; }
        public string DriverCollectionName { get; set; }
        public string DriveCollectionName { get; set; }
        public string PackageCollectionName { get; set; }
        public string DriveHistoryCollectionName { get; set; }
        public string PackageHistoryCollectionName { get; set; }

    }
}
