using QuickPoll.Domain.Contracts;
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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public IChoiceRepository Choices { get; set; }
        public IQuestionRepository Questions { get; set; }
        public IPollRepository Polls { get; set; }
        public IUserRepository Users { get; set; }
        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            Choices = new ChoiceRepository(_dbContext);
            Questions = new QuestionRepository(_dbContext);
            Polls = new PollRepository(_dbContext);
            Users = new UserRepository(_dbContext);
        }
        public void SaveUnitOfWork()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string fullmessage = ex.Message;

                if (ex.InnerException is not null)
                {
                    fullmessage += "\n" + ex.InnerException.Message;

                    throw new Exception(fullmessage, ex);

                }
            }
        }
    }
}
