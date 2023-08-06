using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Profiles
{
    internal class PackageProfile : Profile
    {
        /// <summary>
        ///Automper function to convert from Package to PackageDTO and reversed.
        /// </summary>
        public PackageProfile()
        {
            CreateMap<Package, PackageDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();
        }
    }
}
