using QuickPoll.Domain.Contracts.Reposotories;
using QuickPoll.Domain.Entities;
using QuickPoll.InfraStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPoll.Infrastructure.Repositories
{
    public class NormalUserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        public NormalUserRepository(AppDbContext dbContext) => _dbContext = dbContext; 
        public int Login(string username, string password)
        {
            return _dbContext.NormalUsers.FirstOrDefault(u => u.UserName == username && u.Password == password).Id;
        }
    }
}
