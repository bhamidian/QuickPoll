using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPoll.ApplicationService.DTOs
{
    public class GetQuestionDTO
    {
        public string Description { get; set; }
        public string OptionOne { get; set; }
        public string OptionTwo { get; set; }
        public string OptionThree { get; set; }
        public string OptionFour { get; set; }
       

    }
}
