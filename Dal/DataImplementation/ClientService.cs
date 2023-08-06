
namespace Dal.DataImplementation
{
    public class ClientService : IClientService
    {
        private IMongoCollection<Client> ClientCollection { get; }
        public ClientService(IDataContext db)
        {
            ClientCollection = db.ClientCollection;
        }

        #region Create functions
        /// <summary>
        /// Create a new client and insert into the DB - sign up as client.
        /// </summary>
        /// <param name="client"></param>
        /// <returns>
        /// Boolean, true if success to create new client, false otherwise.
        /// </returns>
        public async Task<bool> CreateAsync(Client client)
        {
            try
            {
                if (client == null)
                    throw new ArgumentNullException("Client details are null");

                if (ClientCollection
                    .AsQueryable<Client>()
                    .Where(c => c.ID == client.ID)
                    .FirstOrDefault() != null)
                {
                    throw new Exception("This ID already exists in the system");
                   
                }
                if (ClientCollection
                    .AsQueryable<Client>()
                    .Where(c =>  c.UserName == client.UserName && c.Password == client.Password)
                    .FirstOrDefault() != null)
                {
                    throw new Exception("The password is not strong enough");

                }
                else
                {
                    await ClientCollection.InsertOneAsync(client);
                    return true;
                }

            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception) { throw ; }
        }
        #endregion

        #region Get functions
        /// <summary>
        /// Get all the clients from the DB.
        /// </summary>
        /// <returns>
        /// The list of all clients from the DB.
        /// </returns>
        public async Task<List<Client>> GetAllAsync()
        {
            try
            {
                List<Client> clients = await ClientCollection.AsQueryable<Client>().ToListAsync();
                return clients == null ? throw new ArgumentNullException("No clients in our system") : clients;
            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine(ex);
                throw ex;
            }
            catch (TimeoutException ex) { throw ex; }

        }

        /// <summary>
        /// Get a client from the DB according to the ID it received.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// A client object.
        /// </returns>
        public async Task<Client> GetByIdAsync(string id)
        {
            try
            {
                Client client = await ClientCollection.Find(client => client.ID == id).FirstOrDefaultAsync();
                if (client == null)
                {
                    throw new ArgumentNullException("The client does'nt exist in our system");
                }
                return client;
            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }
        /// <summary>
        /// Get a client from the DB according to the userName and password it received.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>
        /// A client object.
        /// </returns>
        public async Task<Client> GetByUserNameAndPasswordAsync(string userName, string password)
        {
            try
            {
                Client client = await ClientCollection.Find(client => client.UserName == userName && client.Password == password).FirstOrDefaultAsync();
                if (client == null)
                {
                    throw new ArgumentNullException("Please provide a valid user name and password.");
                }
                return client;
            }
            catch (ArgumentNullException ex) { throw ex; }
        }


        #endregion

        #region Update functions
        /// <summary>
        /// Update client details to DB.
        /// </summary>
        /// <param name="client"></param>
        /// <returns>
        ///Boolean, true if the client information update is successful, false otherwise
        /// </returns>
        public async Task<bool> UpdateAsync(Client client)
        {
            try
            {
                Client c = await ClientCollection.Find(cl => cl.ID == client.ID).FirstOrDefaultAsync();
                client._Id = c._Id;
                await ClientCollection.ReplaceOneAsync(cl => cl.ID == client.ID, client);
                return true;
            }
            catch (ArgumentNullException ex) { throw ex; }
            catch (TimeoutException ex) { throw ex; }
            catch (Exception ) { throw ; }

        }
        #endregion

        #region Delete functions
        /// <summary>
        /// Remove a client from the DB according to the user name and password it received.
        /// </summary>
        /// <param name="details"></param>
        /// <returns>
        /// Boolean, true if success to delete a client, false otherwise
        /// </returns>
        public async Task<bool> DeleteAsync(params string[] details)
        {
            if (details != null)
            {
                var isDeleted = await ClientCollection.DeleteOneAsync(client => client.UserName == details[0] && client.Password == details[1]);
                if (isDeleted.DeletedCount > 0)
                    return true;
                return false;
            }
            return false;

        }
        #endregion
    }
}
