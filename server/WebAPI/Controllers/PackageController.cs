

namespace WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PackageController : ControllerBase
    {

        private readonly IPackageSrviceBL packageServiceBL;
        public PackageController(IPackageSrviceBL packageServiceBL)
        {
            this.packageServiceBL = packageServiceBL;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DriverDTO>))]

        public async Task<ActionResult> CreatePackage(PackageDTO package)
        {
            try
            {
                package.DateTime = DateTime.Now;
                List<DriverDTO>? drivers = await packageServiceBL.CreateWithMatch(package);
                
                return drivers!=null? Ok(drivers):NotFound();
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { 
                throw; }
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
                return await packageServiceBL.GetAllAsync();
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
        public async Task<List<PackageDTO>> GetPackagesByIdAsync(string id)
        {
            try
            {
                return await packageServiceBL.GetByIdAsync(id);
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
        public async Task<bool> UpdatePackage(string id,[FromBody] PackageDTO package)
        {
            try
            {
                return await packageServiceBL.UpdateWithSendigEmailAsync(package);
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
                return await packageServiceBL.DeleteAsync(id);
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }

        }
        #endregion

    }
}