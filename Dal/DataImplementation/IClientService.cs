
namespace Dal.DataImplementation
{
    public interface IClientService:IDataService<Client>
    {
        Task<Client> GetByIdAsync(string id);
        Task<Client> GetByUserNameAndPasswordAsync(string userName, string password);

    }
}