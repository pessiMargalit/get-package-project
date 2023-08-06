namespace BL.BLImplementation
{
    public static class ConvertionClass
{

        #region Convert SimpleAutoMapper function
        /// <summary>
        /// The function converts an object of type U to an object of type T - this is a generic function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="obj"></param>
        /// <returns>
        /// An object converted from type U to T.
        /// </returns>

        public static T SimpleAutoMapper<T, U>(U obj)
    {
        try
        {
            if (obj != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<U, T>().ReverseMap());
                var mapper = config.CreateMapper();
                return mapper.Map<T>(obj);
            }
            else { throw new ArgumentNullException("obj is null!"); }
        }
        catch (ArgumentNullException ex) { throw ex; }
        catch (Exception)
        {

            throw;
        }
    }

    #endregion

        #region Convert driver function

    public static DriverDTO? ConvertDriverToDriverBL(Driver driver)
    {
        if (driver != null)
        {
            DriverDTO d = new(driver.DriverID, driver.FirstName, driver.LastName, driver.PhoneNumber, driver.Email, driver.LicenseNumber, driver.LicensePlateNumber, (CarTypeDTO)driver.CarType, driver.UserName, driver.Password);
            d.Id = driver.Id;
            return d;
        }
        return null;
    }
    public static Driver? ConvertDriverBLToDriver(DriverDTO driver)
    {
        if (driver != null)
        {
            Driver d = new(driver.DriverID, driver.FirstName, driver.LastName, driver.PhoneNumber, driver.Email, driver.LicenseNumber, driver.LicensePlateNumber, ((CarType)driver.CarType), driver.UserName, driver.Password);
            return d;
        }
        return null;
    }
    #endregion


}
}
