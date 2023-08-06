

using System.Text.RegularExpressions;

namespace Dal.Models
{
    public class Package
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _Id { get; set; }
        public string DriverId { get; set; }
        public string DriveId { get; set; }
        public string HostId { get; set; }
        public string PhoneOfdestination { get; set; }
        public Address Source { get; set; }
        public Address Destination { get; set; }
        public int Price { get; set; }
        public Size Size { get; set; }
        public bool IsMatch { get; set; }
        public bool IsTaken { get; set; }
        public bool OnTheWay { get; set; }
        public DateTime DateTime { get; set; }
        public Package()
        {

        }
        public Package(string hostId, string phoneOfdestination, Address source, Address destination, Size size, DateTime dateTime)
        {
            HostId = hostId;
            PhoneOfdestination = phoneOfdestination;
            Source = source;
            Destination = destination;
            Size = size;
            IsMatch = false;
            DateTime = dateTime;

        }

        public Package(string driverId, string driveId, string hostId, string phoneOfdestination, Address source, Address destination, Size size, DateTime dateTime)
        {
            _Id = "";
            DriverId = driverId;
            DriveId = driveId;
            HostId = hostId;
            PhoneOfdestination = phoneOfdestination;
            Source = source;
            Destination = destination;
            Size = size;
            IsMatch = false;
            DateTime = dateTime;

        }
        public Package(string driverId, string driveId, string hostId, int price, string phoneOfdestination, Address source, Address destination, Size size, DateTime dateTime)
        {
            _Id = "";
            DriverId = driverId;
            DriveId = driveId;
            HostId = hostId;
            Price = price;
            PhoneOfdestination = phoneOfdestination;
            Source = source;
            Destination = destination;
            Size = size;
            IsMatch = false;
            DateTime =dateTime;
        }


    }
}
