using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPoll.Domain.Entities
{
    public class Question : BaseEntity
    {

        public string QuestionNumber { get; set; }
        public string Description { get; set; }
        public Poll Poll { get; set; } 
        public int PollId { get; set; }
        public List<Choice> Choices { get; set; } = new List<Choice>(4);
        public int ChoiceId { get; set; }
    }
}
