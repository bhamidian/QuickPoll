using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPoll.InfraStructure
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("\"Server=(localdb)\\\\MSSQLLocalDB;Database=QuickPollDb;Trusted_Connection=True;\"");
        }

    }
}
