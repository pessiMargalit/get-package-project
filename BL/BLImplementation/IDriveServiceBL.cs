namespace BL.BLImplementation
{
    public interface IDriveServiceBL : IBLService<DriveDTO>
    {

        Task<DriveDTO> GetByIdAsync(string id);
        Task<List<DriveDTO>> GetByDriverIdAsync(string id);

    }
}