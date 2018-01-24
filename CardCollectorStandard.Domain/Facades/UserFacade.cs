using AutoMapper;
using CardCollectorStandard.Domain.Dtos;
using CardCollectorStandard.Domain.Services;

namespace CardCollectorStandard.Domain.Facades
{
    public interface IUserFacade
    {
        void CreateUser(UserRequestDto request);
        UserResponseDto ValidateUser(UserRequestDto request);
    }

    public class UserFacade : IUserFacade
    {
        public IUserService UserService { get; set; }

        public void CreateUser(UserRequestDto request)
        {
            this.UserService.CreateUser(request.Username, request.Password);
        }

        public UserResponseDto ValidateUser(UserRequestDto request)
        {
            return Mapper.Map<UserResponseDto>(this.UserService.ValidateUser(request.Username, request.Password));
        }
    }
}
