namespace BL.BLImplementation
{
    public interface IMatch
    {
        List<DriverDTO> MatchPackage(PackageDTO p);
        bool SendEmailtoClientAndDriver(PackageDTO package);
    }
}