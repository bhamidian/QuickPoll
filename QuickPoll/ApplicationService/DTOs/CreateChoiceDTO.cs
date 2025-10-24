using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPoll.ApplicationService.DTOs
{
    public class CreateChoiceDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsCorrect { get; set; }

    }
}
