using QuickPoll.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPoll.ApplicationService.DTOs
{
    public class LoginResultDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public Role? Role { get; set; }
        public bool IsAuthenticate { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
