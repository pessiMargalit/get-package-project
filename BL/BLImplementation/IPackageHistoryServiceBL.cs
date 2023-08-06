namespace BL.BLImplementation
{
    public interface IPackageHistoryServiceBL : IBLService<PackageDTO>
    {
     //   Task<bool> CheckingIfThePackageWasTakenByADriver(List<DriverDTO> drivers, PackageDTO package);
        Task<bool> CreateAsync(PackageDTO package);
        Task<List<DriverDTO>?> CreateWithMatch(PackageDTO package);
        Task<bool> DeleteAsync(params string[] details);
        Task<List<PackageDTO>> GetAllAsync();
        Task<List<PackageDTO>> GetByClientIdAsync(string clientId);
        Task<List<PackageDTO>> GetByDriveIdAsync(string driveId);
        Task<List<PackageDTO>> GetByDriverIdAsync(string driverId);
        Task<List<PackageDTO>> GetByIdAsync(string id);
        Task<bool> UpdateAsync(PackageDTO package);
    }
}