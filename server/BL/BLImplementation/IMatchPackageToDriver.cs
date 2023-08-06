
namespace BL.BLImplementation
{
    public interface IMatchPackageToDriver
    {
       List<DriverDTO> Match(PackageDTO package, List<DriverDTO> drivers);
    }
}