using QuickPoll.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace QuickPoll.Domain.Entities
{
    public abstract class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }


    }
}
