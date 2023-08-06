

namespace Dal.DataImplementation
{
    public class DriveService : IDriveService
    {
        private IMongoCollection<Drive> DriveCollection { get; }

        public DriveService(IDataContext db)
        {
            DriveCollection = db.DriveCollection;
        }

        #region Create functions
        /// <summary>
        /// Create a new drive and insert into the DB.
        /// </summary>
        /// <param name="drive"></param>
        /// <returns>
        /// Boolean, true if success to create new drive, false otherwise
        /// </returns>
        public async Task<bool> CreateAsync(Drive drive)
        {
            try
            {
                if (drive == null)
                    throw new ArgumentNullException("Drive details are null");
                await DriveCollection.InsertOneAsync(drive);
                return true;

            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }
        #endregion

        #region Get functions
        /// <summary>
        /// Get all the drives from the DB.
        /// </summary>
        /// <returns>
        /// The list of all drives from the DB.
        /// </returns>
        public async Task<List<Drive>> GetAllAsync()
        {
            try
            {
                List<Drive> drives = await DriveCollection.AsQueryable<Drive>().ToListAsync();
                return drives == null ? throw new ArgumentNullException("No drives in our system") : drives;
            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine(ex);
                throw ex;
            }
            catch (TimeoutException ex) { throw ex; }
        }

        /// <summary>
        /// Get a driver from the DB according to the id it received.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// A drive object.
        /// </returns>
        public async Task<Drive> GetByIdAsync(string id)
        {
            try
            {
                Drive drive = await DriveCollection.Find(d => d._Id == id).FirstOrDefaultAsync();
                if (drive == null)
                {
                    throw new ArgumentNullException("The drive does'nt exist in our system");
                }
                return drive;
            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Get a drive from the DB according to the driver id it received.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// A drive object.
        /// </returns>
        public async Task<List<Drive>> GetByDriverIdAsync(string id)
        {
            try
            {
                List<Drive> drives = await DriveCollection.AsQueryable<Drive>().Where(d => d.DriverID == id).ToListAsync();

                if (drives == null)
                {
                    throw new ArgumentNullException("This driver's drives does not exist in our system");

                }
                return drives;
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }


        #endregion

        #region Update functions
        /// <summary>
        /// Update drive details to DB.
        /// </summary>
        /// <param name="drive"></param>
        /// <returns>
        /// Boolean, true if the driver information update is successful, false otherwise
        /// </returns>
        public async Task<bool> UpdateAsync(Drive drive)
        {
            try
            {
                await DriveCollection.ReplaceOneAsync(d => d._Id == drive._Id, drive);
                return true;
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }
        #endregion

        #region Delete functions
        /// <summary>
        /// Delete a drive from the DB according to the id it received.
        /// </summary>
        /// <param name="details"></param>
        /// <returns>
        /// Boolean, true if success to delete a drive, false otherwise
        /// </returns>
        public async Task<bool> DeleteAsync(params string[] details)
        {
            if (details != null)
            {
                var isDeleted = await DriveCollection.DeleteOneAsync(drive => drive._Id == details[0]);
                if (isDeleted.DeletedCount > 0)
                    return true;
                return false;
            }
            return false;
        }
        #endregion

    }
}
