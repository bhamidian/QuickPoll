using QuickPoll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPoll.ApplicationService.DTOs.CreatePollDTO
{
    public class CreateQuestionDTO
    {
        public string QuestionNumber { get; set; }
        public string Description { get; set; }

        public List<Choice> Choices { get; set; }
    }
}
