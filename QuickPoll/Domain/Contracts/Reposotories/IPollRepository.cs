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
    public interface IPollRepository
    {
        void Delete(int id);
        List<Poll> GetAll();
        GetPollDTO? GetPollById(int id);
        void Add(Poll poll);
        //Poll Create(CreatePollDTO pollDTO);
        Poll GetPollEntityById(int id);



    }
}
