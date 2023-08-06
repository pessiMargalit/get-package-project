


namespace Dal.DataImplementation
{
    public interface IDriverService :IDataService<Driver>
    {
        Task<Driver> GetByIdAsync(string id);
        Task<Driver> GetByUserNameAndPasswordAsync(string userName,string password);

    }
}