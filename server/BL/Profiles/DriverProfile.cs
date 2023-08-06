using AutoMapper.Extensions.EnumMapping;
namespace BL.Profiles
{
    internal class DriverProfile : Profile
    {
        /// <summary>
        ///Automper function to convert from driver to driverDTO and reversed.
        /// </summary>
        public DriverProfile()
        {
            CreateMap<Driver, DriverDTO>()
                //.ConvertUsingEnumMapping(opt=>opt.MapValue(CarType,CarTypeDTO))
                .ReverseMap();

            CreateMap<CarType, CarTypeDTO>().ReverseMap();
        }
    }
}
