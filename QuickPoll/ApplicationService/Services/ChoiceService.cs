using QuickPoll.ApplicationService.DTOs;
using QuickPoll.ApplicationService.DTOs.CreatePollDTO;
using QuickPoll.Domain.Contracts.Reposotories;
using QuickPoll.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPoll.ApplicationService.Services
{
    public class ChoiceService : IChoiceService
    {
        private readonly IChoiceRepository _choiceRepository;

        public ChoiceService(IChoiceRepository choiceRepository) => _choiceRepository = choiceRepository;


        public ResultDTO? IsChoiceExist(string name)
        {
            var isexist = _choiceRepository.IsChoiceExist(name);

            if (isexist)
                return new ResultDTO { IsCorrect = true, Message = "choice exist!" };

            return new ResultDTO { IsCorrect = false };


        }


    }
}
