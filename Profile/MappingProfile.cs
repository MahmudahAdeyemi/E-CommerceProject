using AutoMapper;
using E_Commerce_2.Entities;
using E_Commerce_2.RequestModel;

namespace E_Commerce_2.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRequestModel, User>().ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }
}