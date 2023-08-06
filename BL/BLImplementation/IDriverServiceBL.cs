namespace BL.BLImplementation
{
    public interface IDriverServiceBL : IBLService<DriverDTO>
    {
     
        Task<DriverDTO> GetByIdAsync(string id);
        Task<DriverDTO> GetByUserNameAndPasswordAsync(string userName, string password);

    }
}