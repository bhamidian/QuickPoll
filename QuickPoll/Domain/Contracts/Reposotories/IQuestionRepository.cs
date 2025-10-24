using QuickPoll.ApplicationService.DTOs;
using QuickPoll.ApplicationService.DTOs.CreatePollDTO;
using QuickPoll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPoll.Domain.Contracts.Reposotories
{
    public interface IQuestionRepository
    {
        Question Create(CreateQuestionDTO questionDTO, List<Choice> choices);


    }
}
