using QuickPoll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPoll.ApplicationService.DTOs
{
    public class CreateQuestionDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<CreateChoiceDTO> Choices { get; set; } = [];
    }
}
