using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPoll.Domain.Entities
{
    public class NormalUser : Admin
    {
        public List<Poll> Polls { get; set; }
        public int PollId { get; set; }
        public Choice Choice { get; set; }
        public int ChoiceId { get; set; }
    }
}
