using Dal.DataImplementation;
using Dal.Models;

namespace BL.BLImplementation
{
    public class ClientServiceBL : IClientServiceBL
    {
        private IClientService clientService;
        private IPackageSrviceBL packageSrvice;
        public ClientServiceBL(IClientService client, IPackageSrviceBL package)
        {
            clientService = client;
            packageSrvice = package;
        }

        #region Create functions
        /// <summary>
        /// Call the Create function on Dal to create a new client.
        /// </summary>
        /// <param name="client"></param>
        /// <returns>
        /// Boolean, true if success to create a new client, false otherwise.
        /// </returns>
        public async Task<bool> CreateAsync(ClientDTO client)
        {
            try
            {
                if (client != null)
                {
                    Client c = ConvertionClass.SimpleAutoMapper<Client, ClientDTO>(client);
                    if (c != null)
                        return await clientService.CreateAsync(c);
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
        /// Call the GetAll function on Dal to get all clients.
        /// </summary>
        /// <returns>
        /// The list of all clients.
        /// </returns>
        public async Task<List<ClientDTO>> GetAllAsync()
        {
            try { 
            List<ClientDTO> clientsBL = new();
            var clients = await clientService.GetAllAsync();
                if(clients == null)
                    throw new ArgumentNullException("The action failed, please try again later");
                foreach (var client in clients)
            {
                    ClientDTO c = ConvertionClass.SimpleAutoMapper<ClientDTO, Client>(client);
                    c.Packages = await packageSrvice.GetByClientIdAsync(c.ID);
                    clientsBL.Add(c);
            }
            return clientsBL;
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Call the GetByIdAsync function on Dal to get a client from the DB according to the ID it received
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// A client object.
        /// </returns>
        public async Task<ClientDTO> GetByIdAsync(string id)
        {
            try {
                Client c = await clientService.GetByIdAsync(id);
                if (c == null)
                    throw new ArgumentNullException("The client does'nt exist in our system");
                ClientDTO client = ConvertionClass.SimpleAutoMapper<ClientDTO, Client>(c);
                client.Packages = await packageSrvice.GetByClientIdAsync(c.ID);
                return client;
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }

        }

        /// <summary>
        /// Call the GetByIdAsync function on Dal to get a client from the DB according to the userName and password it received
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>
        /// A client object.
        /// </returns>
        public async Task<ClientDTO> GetByUserNameAndPasswordAsync(string userName, string password)
        {
            try {
                Client c = await clientService.GetByUserNameAndPasswordAsync(userName, password);
               if (c == null)
                    throw new ArgumentNullException("The client does'nt exist in our system");
                ClientDTO client = ConvertionClass.SimpleAutoMapper<ClientDTO, Client>(c);
                client.Packages = await packageSrvice.GetByClientIdAsync(c.ID);
                return client;

            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }

        #endregion

        #region Update functions
        /// <summary>
        /// Call the Update function on Dal to update a client.
        /// </summary>
        /// <param name="client"></param>
        /// <returns>
        /// Boolean, true if success to update the client details, false otherwise.
        /// </returns>
        public async Task<bool> UpdateAsync(ClientDTO client)
        {
            try
            {
                if (client != null)
                {
                    Client? c = ConvertionClass.SimpleAutoMapper<Client, ClientDTO>(client);

                    return await clientService.UpdateAsync(c);
                }
                else throw new ArgumentNullException("Failed to update client information, please try again later");
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw; }
        }
        #endregion

        #region Delete functions
        /// <summary>
        /// Call the Delete function on Dal to remove a client.
        /// </summary>
        /// <param name="details"></param>
        /// <returns>
        /// Boolean, true if success to remove a client, false otherwise.
        /// </returns>
        public async Task<bool> DeleteAsync(params string[] details)
        {
            try
            {
                if (details != null)
                {
                    return await clientService.DeleteAsync(details);
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
