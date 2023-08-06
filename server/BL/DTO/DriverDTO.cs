
namespace BL.DTO
{
    public class DriverDTO
    {
        public string Id { get; set; }
        public string DriverID { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string LicenseNumber { get; set; }
        public string LicensePlateNumber { get; set; }
        public CarTypeDTO CarType { get; set; }
        public List<DriveDTO> Drives { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; } //נדרשת הצפנה

        public DriverDTO()
        {
            Id = "";
            FirstName = "";
            LastName = "";
            PhoneNumber = "";
            Email = "";
            LicenseNumber = "";
            LicensePlateNumber = "";
            CarType = 0;
            UserName = "";
            Password = "";
            Drives = new();

        }

        public DriverDTO(string id, string firstName, string lastName, string phoneNumber, string email, string licenseNumber, string licensePlateNumber, CarTypeDTO carType, string userName, string password)
        {
            DriverID = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            LicenseNumber = licenseNumber;
            LicensePlateNumber = licensePlateNumber;
            CarType = carType;
            UserName = userName;
            Password = password;
            Drives = new();
        }

    }
}
