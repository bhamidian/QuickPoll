using QuickPoll.ApplicationService.DTOs.CreatePollDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPoll.Domain.Contracts.Reposotories
{
    public interface IPollRepository
    {
        void Create(CreatePollDTO pollDTO, CreateQuestionDTO questionDTO, CreateChoiceDTO choiceDTO);

    }
}
