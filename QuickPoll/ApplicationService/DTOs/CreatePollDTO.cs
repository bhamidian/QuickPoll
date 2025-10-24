using QuickPoll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPoll.ApplicationService.DTOs.CreatePollDTO
{
    public class CreatePollDTO
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public string Subject { get; set; } 
        public List<CreateQuestionDTO> Questions { get; set; }

    }
}
