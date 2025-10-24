using QuickPoll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPoll.ApplicationService.DTOs
{
    public class GetChoicesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<NormalUser> NormalUsers { get; set; } = [];

    }
}
