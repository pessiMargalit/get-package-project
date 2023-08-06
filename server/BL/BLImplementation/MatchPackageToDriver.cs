

namespace BL.BLImplementation
{
    public class MatchPackageToDriver : IMatchPackageToDriver
    {
        /// <summary>
        /// Checks compatibility between a package and drivers,
        /// who are suitable to take it according to their drives.
        /// </summary>
        /// <param name="package">
        /// The package we want to check for compatibility.
        /// </param>
        /// <param name="drivers">
        /// All the drivers that exist in the system.
        /// </param>
        /// <returns>
        /// The drivers found suitable to take the package.
        /// </returns>
        public List<DriverDTO> Match(PackageDTO package, List<DriverDTO> drivers)
        {
            List<DriverDTO> driversList = new List<DriverDTO>();
            drivers.ForEach(dr =>
            {
                dr.Drives.ForEach(d =>
               {

                   if (d.Source.City == package.Source.City && d.Destination.City == package.Destination.City)
                   {
                       if (CheckCompatibilityOfPackageSizeAndCarType(dr.CarType, package))
                       {
                           package.IsMatch = true;
                           driversList.Add(dr);
                       }

                   }
               });
            });
            return driversList;
        }
        /// <summary>
        ///  Check compatibility of package size and driver's car type.
        /// </summary>
        /// <param name="carType">
        /// The driver's car type.
        /// </param>
        /// <param name="package">
        /// The package to check its size.
        /// </param>
        /// <returns></returns>
        public bool CheckCompatibilityOfPackageSizeAndCarType(CarTypeDTO carType, PackageDTO package)
        {
            switch (carType)
            {
                case CarTypeDTO.motorcycle:
                    if (package.Size.Hight < 10 && package.Size.Width < 10)
                        return true;
                    return false;
                case CarTypeDTO.truck:
                    if (package.Size.Hight < 400 && package.Size.Width < 400)
                        return true;
                    return false;
                case CarTypeDTO.van:
                    if (package.Size.Hight < 170 && package.Size.Width < 170)
                        return true;
                    return false;
                case CarTypeDTO.car_with_2_seats:
                    if (package.Size.Hight < 80 && package.Size.Width < 80)
                        return true;
                    return false;
                case CarTypeDTO.car_with_5_seats:
                    if (package.Size.Hight < 130 && package.Size.Width < 130)
                        return true;
                    return false;
                case CarTypeDTO.car_with_7_8_seats:
                    if (package.Size.Hight < 150 && package.Size.Width < 150)
                        return true;
                    return false;
                default:
                    break;
            }
            return false;
        }
    }

}
