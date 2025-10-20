using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPoll.Domain.Entities
{
    public class Choice : BaseEntity
    {
        public string ChoiceNumber { get; set; }
        public string Name { get; set; }
        public bool IsCorrect { get; set; }
        public List<NormalUser> NormalUsers { get; set; }
        public int NormalUserId { get; set; }
       
    }
}
