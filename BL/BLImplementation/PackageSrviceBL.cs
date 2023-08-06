
using Timer = System.Timers.Timer;

namespace BL.BLImplementation
{
    public class PackageSrviceBL : IPackageSrviceBL
    {
        private IPackageSrvice packageService;
        private Lazy<IMatch> match;
        private readonly Timer timer;
        IMapper mapper;
        public PackageSrviceBL(IPackageSrvice package, IMapper mapper, Lazy<IMatch> match)
        {
            packageService = package;
            this.mapper = mapper;
            this.match = match;
            timer = new Timer();
            timer.Interval = (60 * 60 * 1000);
            timer.Elapsed +=(object? sender, ElapsedEventArgs e) =>
            {
                CheckingIfThePackageWasTakenByADriver();
            };
                
            timer.Start();
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
                    Package p = mapper.Map<PackageDTO, Package>(package);
                    if (p != null)
                    {
                        return await packageService.CreateAsync(p);
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
                    package._Id = packageService.GetByClientIdAsync(package.HostId).Result
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


        /// <summary>
        /// Call HasThePackageBeenPickedUp function to Check if the package was taken by the driver,
        /// and updates the package details as needed.
        /// </summary>
        /// <param name="drivers">
        /// The drivers who send them an email with an offer to take the package.
        /// </param>
        /// <param name="package">
        /// The package we are looking for a match for.
        /// </param>
        /// <returns>
        /// Boolean -True, if the package is taken by a driver,otherwise false.
        /// </returns>
        public async void CheckingIfThePackageWasTakenByADriver()
        {
            List<DriverDTO>? drivers;
            List<PackageDTO> packages = await GetAllAsync();
            if (packages.Any())
            {
                packages.ForEach(p => { if (!p.IsMatch) match.Value.MatchPackage(p); }) ;
                
            }
           
        }
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
                var packages = await packageService.GetAllAsync();
                if (packages == null)
                    throw new ArgumentNullException("The action failed, please try again later");
                foreach (var package in packages)
                {
                    packageBL.Add(mapper.Map<Package, PackageDTO>(package));

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
                List<Package> packages = await packageService.GetByIdAsync(id);
                if (packages == null)
                    throw new ArgumentNullException("The package does'nt exist in our system");
                return mapper.Map<List<Package>, List<PackageDTO>>(packages);
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
                List<Package> packages = await packageService.GetByDriverIdAsync(driverId);
                if (packages == null)
                    throw new ArgumentNullException("The package does'nt exist in our system");
                return mapper.Map<List<Package>, List<PackageDTO>>(packages);
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
                List<Package> packages = await packageService.GetByDriveIdAsync(driveId);
                if (packages == null)
                    throw new ArgumentNullException("The package does'nt exist in our system");
                return mapper.Map<List<Package>, List<PackageDTO>>(packages);
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
                List<Package> packages = await packageService.GetByClientIdAsync(clientId);
                if (packages == null)
                    throw new ArgumentNullException("The package does'nt exist in our system");
                return mapper.Map<List<Package>, List<PackageDTO>>(packages);
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
                   bool b = await packageService.UpdateAsync(mapper.Map<PackageDTO, Package>(package));
                   
                    return b;
                }
                else throw new ArgumentNullException("Failed to update package information, please try again later");
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }



        public async Task<bool> UpdateWithSendigEmailAsync(PackageDTO package)
        {
            try
            {
                bool isDone = false;
                if (package != null)
                {
                    bool b = await UpdateAsync(package);
                    if (b)
                    {
                        isDone = match.Value.SendEmailtoClientAndDriver(package);
                    }
                    return b && isDone;
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
                    return await packageService.DeleteAsync(details);
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
