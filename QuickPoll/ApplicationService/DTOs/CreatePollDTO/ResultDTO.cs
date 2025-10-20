using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPoll.ApplicationService.DTOs.CreatePollDTO
{
    public class ResultDTO
    {
        public string Message { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
    }
}
