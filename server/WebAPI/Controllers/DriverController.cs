
using BL.BLImplementation;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : ControllerBase
    {
        private readonly IDriverServiceBL driverServiceBL;
        public DriverController(IDriverServiceBL driverServiceBL)
        {
            this.driverServiceBL = driverServiceBL;
        }
        #region Create functions
        /// <summary>
        /// Call the Create function on BL to create a new driver.
        /// </summary>
        /// <param name="driver"></param>
        /// <returns>
        /// Boolean, true if success to create a new driver, false otherwise.
        /// </returns>
        [HttpPost]
        public async Task<bool> SighnUpAsDriver(DriverDTO driver)
        {
            try
            {
                return await driverServiceBL.CreateAsync(driver);
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }

        }
        #endregion

        #region Get functions
        /// <summary>
        /// Call the GetAll function on BL to get all drivers.
        /// </summary>
        /// <returns>
        /// The list of all drivers.
        /// </returns>

        [HttpGet]
        public async Task<List<DriverDTO>> GetAllDriversAsync()
        {
            try
            {
                return await driverServiceBL.GetAllAsync();
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }

        }

        /// <summary>
        /// Call the GetByIdAsync function on BL to get a driver from the DB according to the ID it received.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// A driver object.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<DriverDTO> GetDriversByIdAsync(string id)
        {
            try
            {
                return await driverServiceBL.GetByIdAsync(id);
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }

        }

        /// <summary>
        /// Call the GetByUserNameAndPassword function on BL to get a driver from the DB according to the userName and password it received
        /// </summary>
        /// <param name="user"></param>
        /// <returns>
        /// A driver object.
        /// </returns>
        [HttpPost("name")]
        public async Task<DriverDTO> GetClientByUserNameAndPasswordAsync([FromBody] User user)
        {
            try
            {
                return await driverServiceBL.GetByUserNameAndPasswordAsync(user.UserName, user.Password);
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }

        }

        #endregion

        #region Update function
        /// <summary>
        ///  Call the Update function on BL to update a driver.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="driver"></param>
        /// <returns>
        ///  Boolean, true if success to update the driver details, false otherwise.
        /// </returns>
        [HttpPut("{id}")]
        public async Task<bool> UpdateDriver(int id, [FromBody] DriverDTO driver)
        {
            try
            {
                return await driverServiceBL.UpdateAsync(driver);
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }

        }


        #endregion

        #region Delete function
        /// <summary>
        /// Call the Delete function on BL to remove a driver.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>
        /// Boolean, true if success to delete a driver, false otherwise.
        /// </returns>
        [HttpDelete("delete")]
        public async Task<bool> DeleteDriver([FromBody] User user)
        {
            try
            {
                return await driverServiceBL.DeleteAsync(user.UserName, user.Password);
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }

        }
        #endregion

    }
}
