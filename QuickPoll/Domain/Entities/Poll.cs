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

        public int AdminId { get; set; }
        public Admin Admin { get; set; }

        public List<Question> Questions { get; set; } = new List<Question>();

        public List<NormalUser> NormalUsers { get; set; } = new List<NormalUser>();
    }
}
