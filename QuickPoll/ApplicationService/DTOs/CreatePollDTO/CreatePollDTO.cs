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
        public string Subject { get; set; } 
        public List<Question> Questions { get; set; }
    }
}
