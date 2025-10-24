using QuickPoll.ApplicationService.DTOs;
using QuickPoll.ApplicationService.DTOs.CreatePollDTO;
using QuickPoll.Domain.Contracts.Reposotories;
using QuickPoll.Domain.Contracts.Services;
using QuickPoll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPoll.ApplicationService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User? GetUserByUsername(string username)
        {
            return _userRepository.GetUserByUsername(username);
        }

        public User? Login(string username, string password)
        {
            var user = _userRepository.Login(username, password);

            return user;

            

        }


    }
}
