using QuickPoll.Domain.Contracts.Reposotories;
using QuickPoll.Domain.Entities;
using QuickPoll.InfraStructure;
using System;
using System.Linq;

namespace QuickPoll.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User? Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Username and password must be provided.");

            return _dbContext.Users
                .FirstOrDefault(u => u.UserName == username && u.Password == password);
        }

        public User? GetUserByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username must be provided.");

            return _dbContext.Users
                .FirstOrDefault(u => u.UserName == username);
        }
    }
}
