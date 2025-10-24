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
    public interface IPollOperationService
    {
        void CreatePoll(CreatePollDTO pollDTO);
        ResultDTO? Delete(int id);
        List<GetPollDTO?> GetAll();
        GetPollDTO? GetPollById(int id);
        Poll GetPollEntityById(int id);
        void TakePoll(int pollId, string username, List<int> inputs);
        PollScoresDTO GetScores(int pollId);




    }
}
