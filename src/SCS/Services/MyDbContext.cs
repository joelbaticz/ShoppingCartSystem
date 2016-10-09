using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SCS.Models;
using Microsoft.EntityFrameworkCore;

namespace SCS.Services
{
    public class MyDbContext : DbContext
    {
        public DbSet<Category> TblCategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer(@"Server=(localdb)\mssqllocaldb ;Database=SCSDatabase ;Trusted_Connection=True;");
        }
        

        

    


    }
}
