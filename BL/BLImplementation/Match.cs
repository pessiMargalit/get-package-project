

namespace BL.BLImplementation
{
    public class Match : IMatch
    {
        private IMatchPackageToDriver match;
        private IDriverServiceBL driverService;
        private IClientServiceBL clientService;

       
        public Match(IMatchPackageToDriver match, IDriverServiceBL driverService, IClientServiceBL clientService)
        {
            this.driverService = driverService;
            this.match = match;
            this.clientService = clientService;
        }

        /// <summary>
        /// Call several functions to find a match between a package and the driver that will take the package.
        ///</summary>
        /// <param name="package">
        /// The package we are looking for a match for.
        /// </param>
        /// <returns>
        /// The drivers found suitable to take the package.
        /// </returns>
        public List<DriverDTO> MatchPackage(PackageDTO package)
        {

            List<DriverDTO> drivers = driverService.GetAllAsync().Result;
            drivers = match.Match(package, drivers);
            if (drivers.Any())
                EmailServiceBL.SendEmail(drivers, package);
           
            return drivers;

        }

        ///// <summary>
        ///// Calls the function that finds which driver approved the package pickup,
        ///// and also calls the function that informs the client that the package has been picked up.
        ///// </summary>
        ///// <param name="package">
        ///// The package we are looking for a match for.
        ///// </param>
        ///// <param name="drivers">
        ///// The drivers who send them an email with an offer to take the package.
        ///// </param>
        ///// <returns>
        ///// The driver who will take the package to its destination.
        ///// </returns>
        public bool SendEmailtoClientAndDriver(PackageDTO package)
        {
            if (package.DriverId != " ")
            {
                DriverDTO? driver = driverService.GetByIdAsync(package.DriverId).Result;
                ClientDTO client = clientService.GetByIdAsync(package.HostId).Result;
                if (driver != null)
                {
                    EmailServiceBL.SendEmailToClient(client, driver,package);
                    EmailServiceBL.SendEmailToDriver(driver, client,package);
                    return true;
                }

            }
            return false;

        }


    }

}
