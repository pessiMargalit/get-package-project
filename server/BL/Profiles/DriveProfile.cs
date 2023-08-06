using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Profiles
{
    internal class DriveProfile : Profile
    {
        /// <summary>
        ///Automper function to convert from drive to driveDTO and reversed.
        /// </summary>
        public DriveProfile()
        {
            CreateMap<Drive, DriveDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();

        }
    }
}
