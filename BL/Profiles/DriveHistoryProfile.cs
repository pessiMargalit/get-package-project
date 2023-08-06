

namespace BL.Profiles
{
    internal class DriveHistoryProfile : Profile
    {
        /// <summary>
      ///Automper function to convert from driveHistory to driveDTO and reversed.
      /// </summary>
        public DriveHistoryProfile()
        {
            CreateMap<DriveHistory, DriveDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();

        }
    }
}
