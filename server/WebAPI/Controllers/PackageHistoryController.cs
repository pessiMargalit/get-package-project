namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackageHistoryController:ControllerBase
    {
        private readonly IPackageHistoryServiceBL packageHistoryServiceBL;
        public PackageHistoryController(IPackageHistoryServiceBL packageHistoryServiceBL)
        {
            this.packageHistoryServiceBL = packageHistoryServiceBL;
        }
        #region Create function
        /// <summary>
        /// Call the Create function on BL to create a new package.
        /// </summary>
        /// <param name="package"></param>
        /// <returns>
        /// Boolean, true if success to create a new package, false otherwise.
        /// </returns>
        [HttpPost]
       

        public async Task<bool> CreatePackage(PackageDTO package)
        {
            try
            {
                return await packageHistoryServiceBL.CreateAsync(package);
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Get function
        /// <summary>
        /// Call the GetAll function on BL to get all packages.
        /// </summary>
        /// <returns>
        /// The list of all packages.
        /// </returns>
        [HttpGet]
        public async Task<List<PackageDTO>> GetAllPackagesAsync()
        {
            try
            {
                return await packageHistoryServiceBL.GetAllAsync();
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }

        }

        /// <summary>
        /// Call the GetById function on BL to get a package from the DB according to the id it received.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// A package object.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<List<PackageDTO>> GetPackagesByClientIdAsync(string id)
        {
            try
            {
                return await packageHistoryServiceBL.GetByClientIdAsync(id);
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }

        #endregion

        #region Update function
        /// <summary>
        ///  Call the Update function on BL to update a package.
        /// </summary>
        /// <param name="package"></param>
        /// <returns>
        ///  Boolean, true if success to update the package details, false otherwise.
        /// </returns>
        [HttpPut("{id}")]
        public async Task<bool> UpdatePackage(string id, [FromBody] PackageDTO package)
        {
            try
            {
                return await packageHistoryServiceBL.UpdateAsync(package);
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }
        #endregion

        #region Delete function
        /// <summary>
        /// Call the Delete function on BL to remove a package.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Boolean, true if success to delete a package, false otherwise.
        /// </returns>
        [HttpDelete("{id}")]
        public async Task<bool> DeletePackage(string id)
        {
            try
            {
                return await packageHistoryServiceBL.DeleteAsync(id);
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }

        }
        #endregion
    }
}
