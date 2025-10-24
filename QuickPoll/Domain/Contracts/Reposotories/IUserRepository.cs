using Azure.Identity;
using QuickPoll.ApplicationService.DTOs.CreatePollDTO;
using QuickPoll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPoll.Domain.Contracts.Reposotories
{
    public interface IUserRepository
    {
        User? GetUserByUsername(string username);
        User? Login(string username, string password);

    }
}
