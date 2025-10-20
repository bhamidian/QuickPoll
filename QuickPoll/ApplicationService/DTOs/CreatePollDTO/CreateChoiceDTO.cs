using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPoll.ApplicationService.DTOs.CreatePollDTO
{
    public class CreateChoiceDTO
    {
        public string Name { get; set; }
        public string ChoiceNumber { get; set; }
        public bool IsCorrect { get; set; }

    }
}
