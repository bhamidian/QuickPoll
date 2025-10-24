using QuickPoll.ApplicationService.DTOs;
using QuickPoll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPoll.Domain.Contracts.Reposotories
{
    public interface IChoiceRepository
    {
        bool IsChoiceExist(string name);
        public Choice CreateChoice(CreateChoiceDTO choiceDTO);


    }
}
