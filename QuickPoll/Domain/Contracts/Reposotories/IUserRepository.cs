using Azure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPoll.Domain.Contracts.Reposotories
{
    public interface IUserRepository
    {
        int Login(string username, string password);
    }
}
