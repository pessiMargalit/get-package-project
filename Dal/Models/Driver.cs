

namespace Dal.Models
{
    public class Driver
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string DriverID { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string LicenseNumber { get; set; }
        public string LicensePlateNumber { get; set; }
        public CarType CarType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; } //נדרשת הצפנה
        public Driver()
        {

        }
        public Driver(string id, string firstName, string lastName, string phoneNumber, string email, string licenseNumber, string licensePlateNumber, CarType carType, string userName, string password)
        {
            Id = "";
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
        }
    }
}
