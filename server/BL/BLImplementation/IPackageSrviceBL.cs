namespace BL.BLImplementation
{
    public interface IPackageSrviceBL : IBLService<PackageDTO>
    {

        Task<List<PackageDTO>> GetByDriverIdAsync(string id);
        Task<List<PackageDTO>> GetByDriveIdAsync(string id);
        Task<List<PackageDTO>> GetByClientIdAsync(string clientId);
        Task<List<PackageDTO>> GetByIdAsync(string id);
        Task<List<DriverDTO>?> CreateWithMatch(PackageDTO package);
        Task<bool> UpdateWithSendigEmailAsync(PackageDTO package);
    }
}