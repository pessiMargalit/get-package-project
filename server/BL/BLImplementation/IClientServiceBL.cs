namespace BL.BLImplementation
{
    public interface IClientServiceBL : IBLService<ClientDTO>
    {
        Task<ClientDTO> GetByIdAsync(string id);
        Task<ClientDTO> GetByUserNameAndPasswordAsync(string userName, string password);


    }
}