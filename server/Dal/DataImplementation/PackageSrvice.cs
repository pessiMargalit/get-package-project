

namespace Dal.DataImplementation
{
    public class PackageSrvice : IPackageSrvice
    {
        private IMongoCollection<Package> PackageCollection { get; }
        public PackageSrvice(IDataContext db)
        {
            PackageCollection = db.PackageCollection;
        }

        #region Create functions
        /// <summary>
        ///  Create a new package and insert into the DB.
        /// </summary>
        /// <param name="package"></param>
        /// <returns>
        /// Boolean, true if success to create new package, false otherwise
        /// </returns>
        public async Task<bool> CreateAsync(Package package)
        {
            try
            {
                if (package == null)
                    throw new ArgumentNullException("Package details are null");

                await PackageCollection.InsertOneAsync(package);
                return true;

            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception ) { throw ; }
        }
        #endregion

        #region Get functions
        /// <summary>
        /// Get all the packages from the DB.
        /// </summary>
        /// <returns>
        /// The list of all packages from the DB.
        /// </returns>
        public async Task<List<Package>> GetAllAsync()
        {
            try
            {
                List<Package> packages = await PackageCollection.AsQueryable<Package>().ToListAsync();
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
        public async Task<List<Package>> GetByIdAsync(string id)
        {
            try
            {
                List<Package> packages = await PackageCollection.AsQueryable<Package>().Where(p => p._Id == id).ToListAsync();

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
        public async Task<List<Package>> GetByDriverIdAsync(string id)
        {
            try
            {
                List<Package> packages = await PackageCollection.AsQueryable<Package>().Where(p => p.DriverId == id).ToListAsync();

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
        public async Task<List<Package>> GetByDriveIdAsync(string id)
        {
            try
            {
                List<Package> packages = await PackageCollection.AsQueryable<Package>().Where(p => p.DriveId == id).ToListAsync();

                if (packages == null)
                {
                    throw new ArgumentNullException("The package for this drive doesn't exist in our system") ;
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
        public async Task<List<Package>> GetByClientIdAsync(string id)
        {
            try
            {
                List<Package> packages = await PackageCollection.AsQueryable<Package>().Where(p => p.HostId == id).ToListAsync();

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
        public async Task<bool> UpdateAsync(Package package)
        {
            try
            {
                await PackageCollection.ReplaceOneAsync(p => p._Id == package._Id, package);
                return true;
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception ) { throw ; }
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
                var isDeleted = await PackageCollection.DeleteOneAsync(package => package._Id == details[0]);
                if (isDeleted.DeletedCount > 0)
                    return true;
                return false;
            }
            return false;
        }


        #endregion
    }
}
