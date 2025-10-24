using Microsoft.Identity.Client;
using QuickPoll.ApplicationService.DTOs;
using QuickPoll.ApplicationService.DTOs.CreatePollDTO;
using QuickPoll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPoll.Domain.Contracts.Services
{
    public interface IUserService
    {
        User? Login(string username, string password);
        User? GetUserByUsername(string username);






    }
}
