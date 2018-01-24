using AutoMapper;
using CardCollectorStandard.Data;
using CardCollectorStandard.Domain.Models;
using System.Security;

namespace CardCollectorStandard.Domain.Services
{
    public interface IUserService
    {
        User ValidateUser(string username, string password);
        void CreateUser(string username, string password);
    }

    public class UserService : IUserService
    {
        private IPasswordHashingService PasswordHashingService { get; set; }
        private IUserRepository UserRepository { get; set; }

        public void CreateUser(string username, string password)
        {
            var newUserInformation = this.PasswordHashingService.CreateHash(password);
            this.UserRepository.CreateUser(username, newUserInformation.Item1, newUserInformation.Item2);
        }

        public User ValidateUser(string username, string password)
        {
            var user = this.UserRepository.GetUser(username);

            if(this.PasswordHashingService.ValidatePassword(password, user.PasswordHash))
            {
                return Mapper.Map<User>(user);
            }
            else
            {
                throw new SecurityException();
            }
        }
    }
}
