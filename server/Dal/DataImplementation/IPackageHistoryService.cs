namespace Dal.DataImplementation
{
    public interface IPackageHistoryService: IDataService<PackageHistory>
    {
        Task<bool> CreateAsync(PackageHistory package);
        Task<bool> DeleteAsync(params string[] details);
        Task<List<PackageHistory>> GetAllAsync();
        Task<List<PackageHistory>> GetByClientIdAsync(string id);
        Task<List<PackageHistory>> GetByDriveIdAsync(string id);
        Task<List<PackageHistory>> GetByDriverIdAsync(string id);
        Task<List<PackageHistory>> GetByIdAsync(string id);
        Task<bool> UpdateAsync(PackageHistory package);
    }
}