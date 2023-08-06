

namespace Dal.DataImplementation
{
    public class DriverService : IDriverService
    {
        private IMongoCollection<Driver> DriverCollection { get; }
        public DriverService(IDataContext db)
        {
            DriverCollection = db.DriverCollection;
        }

        #region Create functions
        /// <summary>
        ///Create a new driver and insert into the DB - sign up as driver.
        /// </summary>
        /// <param name="driver"></param>
        /// <returns>
        ///Boolean, true if success to create new driver, false otherwise.
        /// </returns>
        public async Task<bool> CreateAsync(Driver driver)
        {
            try
            {
                if (driver == null)
                    throw new ArgumentNullException("Driver details are null");

                if (DriverCollection
                    .AsQueryable<Driver>()
                    .Where(d => d.DriverID == driver.DriverID)
                    .FirstOrDefault() == null)
                {
                    await DriverCollection.InsertOneAsync(driver);
                    return true;
                }
                else
                {
                    throw new Exception("This ID already exists in the system");
                }

            }
            catch (ArgumentNullException exc) { throw exc; }
            catch (Exception) { throw; }
        }
        #endregion

        #region Get functions

        /// <summary>
        /// Get all the drivers from the DB.
        /// </summary>
        /// <returns>
        /// The list of all drivers from the DB.
        /// </returns>
        public async Task<List<Driver>> GetAllAsync()
        {
            try
            {
                List<Driver> drivers = await DriverCollection.AsQueryable<Driver>().ToListAsync();
                return drivers == null ? throw new ArgumentNullException("No drivers in our system") : drivers;
            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine(ex);
                throw ex;
            }
            catch (TimeoutException ex) { throw ex; }
        }

        /// <summary>
        /// Get a driver from the DB according to the ID it received.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// A driver object.
        /// </returns>
        public async Task<Driver> GetByIdAsync(string id)
        {
            try
            {
                Driver driver = await DriverCollection.Find(driver => driver.DriverID == id).FirstOrDefaultAsync();
                if (driver == null)
                {
                    throw new ArgumentNullException("The driver does'nt exist in our system");
                }
                return driver;
            }
            catch (ArgumentNullException ex) { throw ex; }
        }

        /// <summary>
        /// Get a driver from the DB according to the userName and password it received.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>
        /// A driver object.
        /// </returns>
        public async Task<Driver> GetByUserNameAndPasswordAsync(string userName, string password)
        {
            try
            {
                Driver driver = await DriverCollection.Find(driver => driver.UserName == userName && driver.Password == password).FirstOrDefaultAsync();
                if (driver == null)
                {
                    throw new ArgumentNullException("Please provide a valid user name and password.");
                }
                return driver;
            }
            catch (ArgumentNullException ex) { throw ex; }
        }


        #endregion

        #region Update functions
        /// <summary>
        /// Update driver details to DB.
        /// </summary>
        /// <param name="driver"></param>
        /// <returns>
        ///Boolean, true if the driver information update is successful, false otherwise
        /// </returns>
        public async Task<bool> UpdateAsync(Driver driver)
        {
            try
            {
                Driver d = await DriverCollection.Find(dr => dr.DriverID == driver.DriverID).FirstOrDefaultAsync();
                driver.Id = d.Id;
                await DriverCollection.ReplaceOneAsync(d => d.DriverID == driver.DriverID, driver);
                return true;
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception ) { throw ; }
        }
        #endregion

        #region Delete functions

        /// <summary>
        /// Remove a driver from the DB according to the user name and password it received.
        /// </summary>
        /// <param name="details"></param>
        /// <returns>
        /// Boolean, true if success to delete a driver, false otherwise
        /// </returns>
        public async Task<bool> DeleteAsync(params string[] details)
        {
            if (details != null)
            {
                var isDeleted = await DriverCollection.DeleteOneAsync(driver => driver.UserName == details[0] && driver.Password == details[1]);
                if (isDeleted.DeletedCount > 0)
                    return true;
                return false;
            }
            return false;
        }
        #endregion

    }
}
