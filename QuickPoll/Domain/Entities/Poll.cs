using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPoll.Domain.Entities
{
    public class Poll : BaseEntity
    {
        public string Subject { get; set; }
        public Admin Admin { get; set; }
        public int AdminId { get; set; }
        public List<Question> Questions { get; set; } = [];
        public int QuestionId { get; set; }
        public List<NormalUser> NormalUsers { get; set; }
        public int NormalUserId { get; set; }


    }
}
