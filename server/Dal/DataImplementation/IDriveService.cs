
namespace Dal.DataImplementation
{
    public interface IDriveService:IDataService<Drive>

    {
        Task<Drive> GetByIdAsync(string id);
        Task<List<Drive>> GetByDriverIdAsync(string id);


    }
}