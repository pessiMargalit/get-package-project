namespace BL.BLImplementation
{
    public interface IDriveHistoryServiceBL
    {
        Task<bool> CreateAsync(DriveDTO drive);
        Task<bool> DeleteAsync(params string[] details);
        Task<List<DriveDTO>> GetAllAsync();
        Task<List<DriveDTO>> GetByDriverIdAsync(string driverId);
        Task<DriveDTO> GetByIdAsync(string id);
        Task<bool> UpdateAsync(DriveDTO drive);
    }
}