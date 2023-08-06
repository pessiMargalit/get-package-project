
namespace Dal.DataImplementation
{
    public interface IPackageSrvice : IDataService<Package>
    {
        Task<List<Package>> GetByDriverIdAsync(string id);
        Task<List<Package>> GetByDriveIdAsync(string id);
        Task<List<Package>> GetByClientIdAsync(string id);
        Task<List<Package>> GetByIdAsync(string id);



    }
}