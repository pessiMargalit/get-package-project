
using Dal.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriveHistoryController : ControllerBase
    {
        private readonly IDriveHistoryServiceBL driveHistoryServiceBL;
        public DriveHistoryController(IDriveHistoryServiceBL driveHistoryServiceBL)
        {
            this.driveHistoryServiceBL = driveHistoryServiceBL;
        }
        #region Create function
        /// <summary>
        /// Call the Create function on BL to create a new drive.
        /// </summary>
        /// <param name="drive"></param>
        /// <returns>
        /// Boolean, true if success to create a new drive, false otherwise.
        /// </returns>
        [HttpPost]
        public async Task<bool> CreateDriveHistory(DriveDTO drive)
        {
            try
            {
                return await driveHistoryServiceBL.CreateAsync(drive);
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }
        #endregion

        #region Get function
        /// <summary>
        /// Call the GetAll function on BL to get all drives.
        /// </summary>
        /// <returns>
        /// The list of all drives.
        /// </returns>
        [HttpGet]
        public async Task<List<DriveDTO>> GetAllAsync()
        {
            try
            {
                return await driveHistoryServiceBL.GetAllAsync();
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }

        }

        /// <summary>
        /// Call the GetByIdAsync function on BL to get a drive from the DB according to the id it received.
        /// </summary>
        /// <param name="driverId"></param>
        /// <returns>
        /// A drive object.
        /// </returns>

        [HttpGet("{driverId}")]
        public async Task<List<DriveDTO>> GetDriveHistoryByDriverIdAsync(string driverId)
        {
            try
            {
                return await driveHistoryServiceBL.GetByDriverIdAsync(driverId);
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }

        #endregion

        #region Update function
        /// <summary>
        ///  Call the Update function on BL to update a drive.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="drive"></param>
        /// <returns>
        ///  Boolean, true if success to update the drive details, false otherwise.
        /// </returns>
        [HttpPut("{id}")]
        public async Task<bool> UpdateDriveHistory(string id, [FromBody] DriveDTO drive)
        {
            try
            {
                return await driveHistoryServiceBL.UpdateAsync(drive);
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }
        #endregion

        #region Delete function
        /// <summary>
        /// Call the Delete function on BL to remove a drive.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Boolean, true if success to delete a drive, false otherwise.
        /// </returns>
        [HttpDelete("{id}")]
        public async Task<bool> DeleteDriveHistory(string id)
        {
            try
            {
                return await driveHistoryServiceBL.DeleteAsync(id);
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }
        #endregion
    }
}

