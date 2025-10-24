using QuickPoll.Domain.Contracts.Reposotories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPoll.Domain.Contracts
{
    public interface IUnitOfWork
    {
        IChoiceRepository Choices { get; set; }
        IQuestionRepository Questions { get; set; }
        IPollRepository Polls { get; set; }
        IUserRepository Users { get; set; }

        void SaveUnitOfWork();
    }
}
