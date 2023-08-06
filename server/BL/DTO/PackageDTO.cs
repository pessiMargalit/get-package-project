

namespace BL.DTO
{
    public class PackageDTO
    {
        public string _Id { get; set; }
        public string? DriverId { get; set; }
        public string? DriveId { get; set; }
        public string HostId { get; set; }
        public string PhoneOfdestination { get; set; }
        public int Price { get; set; } = 0;
        public AddressDTO Source { get; set; }
        public AddressDTO Destination { get; set; }
        public Size Size { get; set; }
        public bool IsMatch { get; set; }
        public bool IsTaken { get; set; }
        public bool OnTheWay { get; set; }
        public DateTime DateTime { get; set; }
        public PackageDTO()
        {

        }
        //public PackageDTO(string hostId, string phoneOfdestination, AddressDTO source, AddressDTO destination, Size size,DateTime dateTime)
        //{
        //    HostId = hostId;
        //    PhoneOfdestination = phoneOfdestination;
        //    Source = source;
        //    Destination = destination;
        //    Size = size;
        //    DateTime = dateTime;    

        //}

        public PackageDTO(string hostId, string phoneOfdestination, AddressDTO source, AddressDTO destination, Size size)
        {
            HostId = hostId;
            PhoneOfdestination = phoneOfdestination;
            Source = source;
            Destination = destination;
            Size = size;
            DateTime = DateTime.Now;

        }

        public PackageDTO(string driverId, string driveId, string hostId, string phoneOfdestination, AddressDTO source, AddressDTO destination, Size size,DateTime dateTime)
        {
            _Id = "";
            DriverId = driverId;
            DriveId = driveId;
            HostId = hostId;
            PhoneOfdestination = phoneOfdestination;
            Source = source;
            Destination = destination;
            Size = size;
            DateTime=dateTime;
        }
        public PackageDTO(string driverId, string driveId, string hostId, string phoneOfdestination, AddressDTO source, AddressDTO destination, Size size)
        {
            _Id = "";
            DriverId = driverId;
            DriveId = driveId;
            HostId = hostId;
            PhoneOfdestination = phoneOfdestination;
            Source = source;
            Destination = destination;
            Size = size;
            DateTime = DateTime.Now;
        }


    }
}
