using QuickPoll.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPoll.Domain.Entities
{
    public class NormalUser : User
    {
        public List<Poll> Polls { get; set; } = new();
        public List<Choice> Choices { get; set; } = new();
    }

}
