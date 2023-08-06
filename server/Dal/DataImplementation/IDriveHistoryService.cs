namespace Dal.DataImplementation
{
    public interface IDriveHistoryService : IDataService<DriveHistory>
    {
        Task<bool> CreateAsync(DriveHistory drive);
        Task<bool> DeleteAsync(params string[] details);
        Task<List<DriveHistory>> GetAllAsync();
        Task<List<DriveHistory>> GetByDriverIdAsync(string id);
        Task<DriveHistory> GetByIdAsync(string id);
        Task<bool> UpdateAsync(DriveHistory drive);
    }
}