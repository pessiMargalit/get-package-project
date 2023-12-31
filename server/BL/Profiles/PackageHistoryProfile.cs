﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Profiles
{
    internal class PackageHistoryProfile : Profile
    {
        /// <summary>
        ///Automper function to convert from PackageHistory to PackageDTO and reversed.
        /// </summary>
        public PackageHistoryProfile()
        {
            CreateMap<PackageHistory, PackageDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();
        }
    }
}
