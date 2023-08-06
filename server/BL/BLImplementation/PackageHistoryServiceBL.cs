

using Dal.DataImplementation;
using Dal.Models;

namespace BL.BLImplementation
{
    public class PackageHistoryServiceBL : IPackageHistoryServiceBL
    {
        private IPackageHistoryService packageHistoryService;
        private IPackageSrviceBL packageSrviceBL;
        private Lazy<IMatch> match;

        IMapper mapper;
        public PackageHistoryServiceBL(IPackageHistoryService package, IMapper mapper, Lazy<IMatch> match, IPackageSrviceBL packageSrviceBL)
        {
            packageHistoryService = package;
            this.mapper = mapper;
            this.match = match;
            this.packageSrviceBL = packageSrviceBL;
        }

        #region Create functions
        /// <summary>
        /// Call the Create function on Dal to create a new package.
        /// </summary>
        /// <param name="package"></param>
        /// <returns>
        /// Boolean, true if success to create a new package, false otherwise.
        /// </returns>
        public async Task<bool> CreateAsync(PackageDTO package)
        {
            try
            {
                if (package != null)
                {
                    PackageHistory p = mapper.Map<PackageDTO, PackageHistory>(package);
                    if (p != null)
                    {
                        return await packageHistoryService.CreateAsync(p);
                    }

                    else
                        throw new ArgumentNullException("The action failed, please try again later");
                }
                else throw new ArgumentNullException("The action failed, please try again later");
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }


        /// <summary>
        /// Call the CreatAsync function to create tha package,
        /// and Call the Match function to match package to driver.
        /// </summary>
        /// <param name="package"></param>
        /// <returns>
        /// List of drivers.
        /// </returns>
        public async Task<List<DriverDTO>?> CreateWithMatch(PackageDTO package)
        {
            List<DriverDTO> drivers;

            if (package != null)
            {
                bool isCreate = await CreateAsync(package);
                if (isCreate)
                {
                    package._Id = packageHistoryService.GetByClientIdAsync(package.HostId).Result
                                            .Where(p => p.Source.City == package.Source.City && p.Destination.City == package.Destination.City).First()._Id;

                    drivers = match.Value.MatchPackage(package);

                    if (drivers.Any())
                    {
                        package.IsMatch = true;

                        bool isUpdate = await UpdateAsync(package);

                        //bool isTaken = await CheckingIfThePackageWasTakenByADriver(drivers, package);

                        return drivers;
                    }
                }

            }
            return null;
        }


        ///// <summary>
        ///// Call HasThePackageBeenPickedUp function to Check if the package was taken by the driver,
        ///// and updates the package details as needed.
        ///// </summary>
        ///// <param name="drivers">
        ///// The drivers who send them an email with an offer to take the package.
        ///// </param>
        ///// <param name="package">
        ///// The package we are looking for a match for.
        ///// </param>
        ///// <returns>
        ///// Boolean -True, if the package is taken by a driver,otherwise false.
        ///// </returns>
        //public async Task<bool> CheckingIfThePackageWasTakenByADriver(List<DriverDTO> drivers, PackageDTO package)
        //{
        //    DriverDTO driver = match.Value.HasThePackageBeenPickedUp(package, drivers);
        //    bool isTaken = driver == null ? false : true;

        //    if (isTaken && driver != null)
        //    {
        //        package.IsTaken = true;
        //        package.DriverId = driver.DriverID;
        //        package.DriveId = driver.Drives.Where(d => d.Destination.City == package.Destination.City && d.Source.City == package.Source.City).FirstOrDefault()._Id;
        //        bool isUpdate = await UpdateAsync(package);
        //    }
        //    return isTaken;
        //}
        #endregion

        #region Get functions
        /// <summary>
        /// Call the GetAll function on Dal to get all packages.
        /// </summary>
        /// <returns>
        /// The list of all packages.
        /// </returns>
        public async Task<List<PackageDTO>> GetAllAsync()
        {
            try
            {
                List<PackageDTO> packageBL = new();
                var packages = await packageHistoryService.GetAllAsync();
                if (packages == null)
                    throw new ArgumentNullException("The action failed, please try again later");
                foreach (var package in packages)
                {
                    packageBL.Add(mapper.Map<PackageHistory, PackageDTO>(package));

                }
                return packageBL;
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }
        /// <summary>
        /// Call the GetByIdAsync function on Dal to get a package from the DB according to the id it received
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// A package object.
        /// </returns>
        public async Task<List<PackageDTO>> GetByIdAsync(string id)
        {
            try
            {
                List<PackageHistory> packages = await packageHistoryService.GetByIdAsync(id);
                if (packages == null)
                    throw new ArgumentNullException("The package does'nt exist in our system");
                return mapper.Map<List<PackageHistory>, List<PackageDTO>>(packages);
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }

        }

        /// <summary>
        /// Call the GetByDriverIdAsync function on Dal to get a package from the DB according to the driver id it received
        /// </summary>
        /// <param name="driverId"></param>
        /// <returns>
        /// A package object.
        /// </returns>
        public async Task<List<PackageDTO>> GetByDriverIdAsync(string driverId)
        {
            try
            {
                List<PackageHistory> packages = await packageHistoryService.GetByDriverIdAsync(driverId);
                if (packages == null)
                    throw new ArgumentNullException("The package does'nt exist in our system");
                return mapper.Map<List<PackageHistory>, List<PackageDTO>>(packages);
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }

        }

        /// <summary>
        /// Call the GetByDriveIdAsync function on Dal to get a package from the DB according to the drive id it received
        /// </summary>
        /// <param name="driveId"></param>
        /// <returns>
        /// A package object.
        /// </returns>
        public async Task<List<PackageDTO>> GetByDriveIdAsync(string driveId)
        {
            try
            {
                List<PackageHistory> packages = await packageHistoryService.GetByDriveIdAsync(driveId);
                if (packages == null)
                    throw new ArgumentNullException("The package does'nt exist in our system");
                return mapper.Map<List<PackageHistory>, List<PackageDTO>>(packages);
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Call the GetByClientIdAsync function on Dal to get a package from the DB according to the client id it received
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns>
        /// A package object.
        /// </returns>
        public async Task<List<PackageDTO>> GetByClientIdAsync(string clientId)
        {
            try
            {
                List<PackageHistory> packages = await packageHistoryService.GetByClientIdAsync(clientId);
                List<PackageDTO> packagesdto ;

                if (packages == null)
                    throw new ArgumentNullException("The package does'nt exist in our system");
                packagesdto = mapper.Map<List<PackageHistory>, List<PackageDTO>>(packages);
                List<PackageDTO> p = packageSrviceBL.GetByClientIdAsync(clientId).Result;
                if (p != null)
                    p = p.Concat(packagesdto).ToList();
                return p;
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }

        }
        #endregion

        #region Update functions
        /// <summary>
        /// Call the Update function on Dal to update a package.
        /// </summary>
        /// <param name="package"></param>
        /// <returns>
        /// Boolean, true if success to update the package details, false otherwise.
        /// </returns>
        public async Task<bool> UpdateAsync(PackageDTO package)
        {
            try
            {
                if (package != null)
                {
                    return await packageHistoryService.UpdateAsync(mapper.Map<PackageDTO, PackageHistory>(package));
                }
                else throw new ArgumentNullException("Failed to update package information, please try again later");
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }
        #endregion

        #region Delete functions
        /// <summary>
        /// Call the Delete function on Dal to delete a package.
        /// </summary>
        /// <param name="details"></param>
        /// <returns>
        /// Boolean, true if success to delete a package, false otherwise.
        /// </returns>

        public async Task<bool> DeleteAsync(params string[] details)
        {
            try
            {
                if (details != null)
                {
                    return await packageHistoryService.DeleteAsync(details);
                }
                return false;
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }



        #endregion
    }
}
