
namespace Dal
{
    public static class ServiceInjectionDal
    {
        public static void InjectionsDal(this IServiceCollection service)
        {
            service.AddSingleton<IDataContext, DataContext>();
            service.AddSingleton<IDriverService,DriverService>();
            service.AddSingleton<IDriveService, DriveService>();
            service.AddSingleton<IClientService, ClientService>();
            service.AddSingleton<IPackageSrvice, PackageSrvice>();
            service.AddSingleton<IDriveHistoryService, DriveHistoryService>();
            service.AddSingleton<IPackageHistoryService, PackageHistoryService>();

        }
    }
}
