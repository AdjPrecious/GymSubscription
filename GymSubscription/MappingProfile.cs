using AutoMapper;
using Entity.Model;
using Shared.DataTransferObjects.AttendanceDto;
using Shared.DataTransferObjects.PlanDto;
using Shared.DataTransferObjects.SubscriptionDto;
using Shared.DataTransferObjects.UserDto;

namespace GymSubscription
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
                /*User Map*/

            CreateMap<UserForRegistrationDto, User>()
                .ForMember(c => c.CreatedAt, opt => opt.MapFrom(_ => DateTime.Now));

            CreateMap<UpdateUserDto, User>().ForMember(c => c.UpdatedAt, opt => opt.MapFrom(_ => DateTime.Now));

            CreateMap<User, UserDto>();

            /*Plan Map*/
            CreateMap<Plan, PlanDto>();
            
            CreateMap<CreatePlanDto, Plan>().ForMember(p => p.CreatedAt, opt => opt.MapFrom(_=> DateTime.Now));

            CreateMap<UpdatePlanDto, Plan>();

            /*Subscription Map*/
            CreateMap<Subscription, SubscriptionDto>();

            /*Attendance map*/
            CreateMap<Attendance, AttendanceDto>();
                
            

           
        }



    }
}
