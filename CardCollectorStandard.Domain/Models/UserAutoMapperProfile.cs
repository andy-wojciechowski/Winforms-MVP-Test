using AutoMapper;

namespace CardCollectorStandard.Domain.Models
{
    public class UserAutoMapperProfile : Profile
    {
        public UserAutoMapperProfile()
        {
            CreateMap<Data.Entities.User, User>();
            CreateMap<User, Dtos.UserResponseDto>();
        }
    }
}
