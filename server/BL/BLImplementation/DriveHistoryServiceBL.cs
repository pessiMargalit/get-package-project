using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BLImplementation
{
    public class DriveHistoryServiceBL : IDriveHistoryServiceBL
    {
        private IDriveHistoryService driveHistoryService;
        private IDriveServiceBL driveService;
        private IPackageSrviceBL packageSrvice;

        IMapper mapper;
        public DriveHistoryServiceBL(IDriveHistoryService driver, IMapper mapper, IPackageSrviceBL package, IDriveServiceBL driveService)
        {
            driveHistoryService = driver;
            this.mapper = mapper;
            packageSrvice = package;
            this.driveService = driveService;
        }

        #region Create functions
        /// <summary>
        /// Call the Create function on Dal to create a new drive.
        /// </summary>
        /// <param name="drive"></param>
        /// <returns>
        /// Boolean, true if success to create a new drive, false otherwise.
        /// </returns>
        public async Task<bool> CreateAsync(DriveDTO drive)
        {
            try
            {
                DriveHistory d = mapper.Map<DriveDTO, DriveHistory>(drive);
                if (d == null)
                    throw new ArgumentNullException("Drive details are null");
                return await driveHistoryService.CreateAsync(d);
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (Exception) { throw; }
        }
        #endregion

        #region Get functions
        /// <summary>
        /// Call the GetAll function on Dal to get all drives.
        /// </summary>
        /// <returns>
        /// The list of all drives.
        /// </returns>
        public async Task<List<DriveDTO>> GetAllAsync()
        {
            try
            {
                List<DriveDTO> driveBL = new();

                var drives = await driveHistoryService.GetAllAsync();
                if (drives == null)
                    throw new ArgumentNullException("The action failed, please try again later");
                foreach (var drive in drives)
                {
                    DriveDTO d = mapper.Map<DriveHistory, DriveDTO>(drive);
                    d.Packages = await packageSrvice.GetByDriveIdAsync(d._Id);
                    driveBL.Add(d);
                }
                return driveBL;
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Call the GetByIdAsync function on Dal to get a drive from the DB according to the id it received
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// A drive object.
        /// </returns>
        public async Task<DriveDTO> GetByIdAsync(string id)
        {
            try
            {
                DriveHistory d = await driveHistoryService.GetByIdAsync(id);
                if (d == null)
                    throw new ArgumentNullException("The drive does'nt exist in our system");
                DriveDTO drive = mapper.Map<DriveHistory, DriveDTO>(d);
                drive.Packages = await packageSrvice.GetByDriveIdAsync(drive._Id);
                return drive;
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Call the GetByDriverIdAsync function on Dal to get a drive from the DB according to the driver id it received
        /// </summary>
        /// <param name="driverId"></param>
        /// <returns>
        /// A drive object.
        /// </returns>
        public async Task<List<DriveDTO>> GetByDriverIdAsync(string driverId)
        {
            try
            {

                List<DriveHistory> drives = await driveHistoryService.GetByDriverIdAsync(driverId);
                if (drives == null)
                    throw new ArgumentNullException("The driver does'nt exist in our system");
                List<DriveDTO> d = mapper.Map<List<DriveHistory>, List<DriveDTO>>(drives);
                d.ForEach(dr => dr.Packages = packageSrvice.GetByDriveIdAsync(dr._Id).Result);
                List<DriveDTO> dr = driveService.GetByDriverIdAsync(driverId).Result;
                if (dr!=null)        
                    dr = dr.Concat(d).ToList();
                return dr;

            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }
        #endregion

        #region Update functions
        /// <summary>
        /// Call the Update function on Dal to update a drive.
        /// </summary>
        /// <param name="drive"></param>
        /// <returns>
        /// Boolean, true if success to update the drive details, false otherwise.
        /// </returns>
        public async Task<bool> UpdateAsync(DriveDTO drive)
        {
            try
            {
                if (drive != null)
                {
                    DriveHistory? d = mapper.Map<DriveDTO, DriveHistory>(drive);

                    return await driveHistoryService.UpdateAsync(d);
                }
                else throw new ArgumentNullException("Failed to update drive information, please try again later");
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }
        #endregion

        #region Delete functions
        /// <summary>
        /// Call the Delete function on Dal to delete a drive.
        /// </summary>
        /// <param name="details"></param>
        /// <returns>
        /// Boolean, true if success to delete a drive, false otherwise.
        /// </returns>
        public async Task<bool> DeleteAsync(params string[] details)
        {
            try
            {
                if (details != null)
                {
                    return await driveHistoryService.DeleteAsync(details);
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
