using CardCollectorStandard.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CardCollectorStandard.Data
{
    public interface IUserRepository
    {
        void CreateUser(string username, string passwordSalt, string passwordHash);
        User GetUser(string username);
    }

    public class UserRepository : IUserRepository
    {
        private CardContext DataContext { get; set; }

        public UserRepository()
        {
            this.DataContext = new CardContext(new DbContextOptions<CardContext>());
        }

        public void CreateUser(string username, string passwordSalt, string passwordHash)
        {
            DataContext.Users.Add(new User
            {
                Username = username,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordSalt
            });
            DataContext.SaveChanges();
        }

        public User GetUser(string username)
        {
            return (from user in DataContext.Users
                    where user.Username.Equals(username)
                    select user).SingleOrDefault();
        }
    }
}
