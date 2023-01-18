using ChainOfResponsibility.UpSchool.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainOfResponsibility.UpSchool.DAL
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-8GBIAO0U\\SQLEXPRESS;Database=DbChainOfResponsibilityUPS;integrated security=true");
        }

        public DbSet<BankProcess> BankProcesses { get; set; }
    }
}
