using AutoMapper;
using Entity.Model;
using Shared.DataTransferObjects;

namespace GymSubscription
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>()
                .ForMember(c => c.CreatedAt, opt => opt.MapFrom(_ => DateTime.Now));
        }



    }
}
