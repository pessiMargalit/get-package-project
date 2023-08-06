namespace BL.BLImplementation
{
    public class DriverServiceBL : IDriverServiceBL
    {
        private IDriverService driverService;
        private IDriveServiceBL driveService;
        IMapper mapper;

        public DriverServiceBL(IDriverService driver, IMapper mapper, IDriveServiceBL drive)
        {
            driverService = driver;
            this.mapper = mapper;
            driveService = drive;
        }

        #region Create functions
        /// <summary>
        /// Call the Create function on Dal to create a new driver.
        /// </summary>
        /// <param name="driver"></param>
        /// <returns>
        /// Boolean, true if success to create a new driver, false otherwise.
        /// </returns>
        public async Task<bool> CreateAsync(DriverDTO driver)
        {
            try
            {
                if (driver != null)
                {
                    Driver d = mapper.Map<DriverDTO, Driver>(driver);
                    if (d != null)
                        return await driverService.CreateAsync(d);
                    else
                        throw new ArgumentNullException("The action failed, please try again later");
                }
                else throw new ArgumentNullException("The action failed, please try again later");
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }
        #endregion

        #region Get functions
        /// <summary>
        /// Call the GetAll function on Dal to get all drivers.
        /// </summary>
        /// <returns>
        /// The list of all drivers.
        /// </returns>
        public async Task<List<DriverDTO>> GetAllAsync()
        {
            try
            {
                List<Driver> drivers = await driverService.GetAllAsync();
                List<DriverDTO> dr = new();
                if (drivers == null)
                    throw new ArgumentNullException("The action failed, please try again later");
                foreach (Driver d in drivers)
                {
                    DriverDTO? driver = ConvertionClass.ConvertDriverToDriverBL(d);
                    driver.Drives = driveService.GetByDriverIdAsync(driver.DriverID).Result;
                    dr.Add(driver);
                    //dr.Add(mapper.Map<Driver, DriverDTO>(d));
                }
                return dr;
                //return mapper.Map<List<Driver>, List<DriverDTO>>(drivers);
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Call the GetByIdAsync function on Dal to get a driver from the DB according to the ID it received.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// A driver object.
        /// </returns>
        public async Task<DriverDTO> GetByIdAsync(string id)
        {
            try
            {
                Driver d = await driverService.GetByIdAsync(id);
                if (d == null)
                    throw new ArgumentNullException("The driver does'nt exist in our system");
                DriverDTO? driver = ConvertionClass.ConvertDriverToDriverBL(d);
                driver.Drives = driveService.GetByDriverIdAsync(driver.DriverID).Result;
                  return driver;
                //return mapper.Map<Driver, DriverDTO>(d);
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }
        /// <summary>
        /// Call the GetByIdAsync function on Dal to get a driver from the DB according to the userName and password it received
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>
        /// A driver object.
        /// </returns>
        public async Task<DriverDTO> GetByUserNameAndPasswordAsync(string userName, string password)
        {
            try
            {
                Driver d = await driverService.GetByUserNameAndPasswordAsync(userName, password);
                if (d == null)
                    throw new ArgumentNullException("The driver does'nt exist in our system");
                DriverDTO? driver = ConvertionClass.ConvertDriverToDriverBL(d);
                driver.Drives = driveService.GetByDriverIdAsync(driver.DriverID).Result;
                return driver;
                //return mapper.Map<Driver, DriverDTO>(d);
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }



        #endregion

        #region Update functions
        /// <summary>
        /// Call the Update function on Dal to update a driver.
        /// </summary>
        /// <param name="d"></param>
        /// <returns>
        /// Boolean, true if success to update the driver details, false otherwise.
        /// </returns>
        public async Task<bool> UpdateAsync(DriverDTO d)
        {
            try
            {
                if (d != null)
                {
                    Driver? driver = mapper.Map<DriverDTO, Driver>(d);
                    return await driverService.UpdateAsync(driver);
                }
                else throw new ArgumentNullException("Failed to update driver information, please try again later");
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }

        }
        #endregion

        #region Delete functions
        /// <summary>
        /// Call the Delete function on Dal to remove a driver.
        /// </summary>
        /// <param name="details"></param>
        /// <returns>
        /// Boolean, true if success to delete a remove, false otherwise.
        /// </returns>
        public async Task<bool> DeleteAsync(params string[] details)
        {
            try
            {
                if (details != null)
                {
                    return await driverService.DeleteAsync(details);
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
