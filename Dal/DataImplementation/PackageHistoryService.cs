using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DataImplementation
{
    internal class PackageHistoryService : IPackageHistoryService
    {
        private IMongoCollection<PackageHistory> PackageHistoryCollection { get; }
        public PackageHistoryService(IDataContext db)
        {
            PackageHistoryCollection = db.PackageHistoryCollection;
        }

        #region Create functions
        /// <summary>
        ///  Create a new package and insert into the DB.
        /// </summary>
        /// <param name="package"></param>
        /// <returns>
        /// Boolean, true if success to create new package, false otherwise
        /// </returns>
        public async Task<bool> CreateAsync(PackageHistory package)
        {
            try
            {
                if (package == null)
                    throw new ArgumentNullException("Package details are null");

                await PackageHistoryCollection.InsertOneAsync(package);
                return true;

            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }
        #endregion

        #region Get functions
        /// <summary>
        /// Get all the packages from the DB.
        /// </summary>
        /// <returns>
        /// The list of all packages from the DB.
        /// </returns>
        public async Task<List<PackageHistory>> GetAllAsync()
        {
            try
            {
                List<PackageHistory> packages = await PackageHistoryCollection.AsQueryable<PackageHistory>().ToListAsync();
                return packages == null ? throw new ArgumentNullException("No packages in our system") : packages;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Get a package from the DB according to the id it received.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        ///  A package object.
        /// </returns>
        public async Task<List<PackageHistory>> GetByIdAsync(string id)
        {
            try
            {
                List<PackageHistory> packages = await PackageHistoryCollection.AsQueryable<PackageHistory>().Where(p => p._Id == id).ToListAsync();

                if (packages == null)
                {
                    throw new ArgumentNullException("This driver's package does not exist in our system");

                }
                return packages;
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Get a package from the DB according to the driver id it received.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        ///  A package object.
        /// </returns>
        public async Task<List<PackageHistory>> GetByDriverIdAsync(string id)
        {
            try
            {
                List<PackageHistory> packages = await PackageHistoryCollection.AsQueryable<PackageHistory>().Where(p => p.DriverId == id).ToListAsync();

                if (packages == null)
                {
                    throw new ArgumentNullException("This driver's package does not exist in our system");

                }
                return packages;
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Get a package from the DB according to the drive id it received.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// A package object.
        /// </returns>
        public async Task<List<PackageHistory>> GetByDriveIdAsync(string id)
        {
            try
            {
                List<PackageHistory> packages = await PackageHistoryCollection.AsQueryable<PackageHistory>().Where(p => p.DriveId == id).ToListAsync();

                if (packages == null)
                {
                    throw new ArgumentNullException("The package for this drive doesn't exist in our system");
                }
                return packages;
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }
        /// <summary>
        /// Get a package from the DB according to the client id it received.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// A package object.
        /// </returns>
        public async Task<List<PackageHistory>> GetByClientIdAsync(string id)
        {
            try
            {
                List<PackageHistory> packages = await PackageHistoryCollection.AsQueryable<PackageHistory>().Where(p => p.HostId == id).ToListAsync();

                if (packages == null)
                {
                    throw new ArgumentNullException("The package for this client doesn't exist in our system");
                }
                return packages;
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }
        #endregion

        #region Update functions
        /// <summary>
        /// Update package details to DB.
        /// </summary>
        /// <param name="package"></param>
        /// <returns>
        /// Boolean, true if the package information update is successful, false otherwise
        /// </returns>
        public async Task<bool> UpdateAsync(PackageHistory package)
        {
            try
            {
                await PackageHistoryCollection.ReplaceOneAsync(p => p._Id == package._Id, package);
                return true;
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }
        #endregion

        #region Delete functions
        /// <summary>
        /// Delete a package from the DB according to the id it received.
        /// </summary>
        /// <param name="details"></param>
        /// <returns>
        /// Boolean, true if success to delete a package, false otherwise
        /// </returns>
        public async Task<bool> DeleteAsync(params string[] details)
        {

            if (details != null)
            {
                var isDeleted = await PackageHistoryCollection.DeleteOneAsync(package => package._Id == details[0]);
                if (isDeleted.DeletedCount > 0)
                    return true;
                return false;
            }
            return false;
        }


        #endregion
    }
}
