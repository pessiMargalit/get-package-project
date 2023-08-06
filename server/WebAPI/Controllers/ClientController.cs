


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientServiceBL clientServiceBL;
        public ClientController(IClientServiceBL clientServiceBL)
        {
            this.clientServiceBL = clientServiceBL;
        }
        #region Create function
        /// <summary>
        /// Call the Create function on BL to create a new client.
        /// </summary>
        /// <param name="client"></param>
        /// <returns>
        /// Boolean, true if success to create a new client, false otherwise.
        /// </returns>
        [HttpPost]
        public async Task<bool> SighnUpAsClient([FromBody] ClientDTO client)
        {
            try
            {
                //ClientDTO client = new(id, firstName, lastName, phoneNumber, email, userName, password);
                return await clientServiceBL.CreateAsync(client);
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }

        }
        #endregion

        #region Get function
        /// <summary>
        /// Call the GetAll function on BL to get all clients.
        /// </summary>
        /// <returns>
        /// The list of all clients.
        /// </returns>
        [HttpGet]
        public async Task<List<ClientDTO>> GetAllClientsAsync()
        {
            try
            {
                return await clientServiceBL.GetAllAsync();
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }

        }

        /// <summary>
        /// Call the GetByIdAsync function on BL to get a client from the DB according to the ID it received.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// A client object.
        /// </returns>

        [HttpGet("{id}")]
        public async Task<ClientDTO> GetClientByIdAsync(string id)
        {
            try
            {

                return await clientServiceBL.GetByIdAsync(id);
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Call the GetByUserNameAndPassword function on BL to get a client from the DB according to the userName and password it received
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>
        /// A client object.
        /// </returns>
        [HttpPost("name")]
        public async Task<ClientDTO> GetClientByUserNameAndPasswordAsync([FromBody] User user)
        {
            try
            {
                return await clientServiceBL.GetByUserNameAndPasswordAsync(user.UserName, user.Password);
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }

        }
        #endregion

        #region Update function
        /// <summary>
        /// Call the Update function on BL to update a client.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="client"></param>
        /// <returns>
        ///  Boolean, true if success to update the client details, false otherwise.
        /// </returns>
        [HttpPut("{id}")]
        public async Task<bool> UpdateClient(int id,[FromBody] ClientDTO client)
        {
            try
            {
                //ClientDTO client = new(id, firstName, lastName, phoneNumber, email, userName, password);
                return await clientServiceBL.UpdateAsync(client);
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }

        }
        #endregion

        #region Delete function
        /// <summary>
        ///Call the Delete function on Dal to remove a client.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>
        /// Boolean, true if success to delete a client, false otherwise.
        /// </returns>
        [HttpDelete("delete")]
        public async Task<bool> DeleteDriver([FromBody] User user)
        {
            try
            {
                return await clientServiceBL.DeleteAsync(user.UserName, user.Password);
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }
        #endregion
    }
}
