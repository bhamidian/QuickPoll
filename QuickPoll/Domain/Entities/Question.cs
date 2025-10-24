using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPoll.Domain.Entities
{
    public class Question : BaseEntity
    {
        public string Description { get; set; }
        public int PollId { get; set; }
        public Poll Poll { get; set; }
        public List<Choice> Choices { get; set; } = new List<Choice>();
    }
}
