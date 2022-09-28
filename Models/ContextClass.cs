using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shakaib_UR_Rehman.Models
{
    public class ContextClass:DbContext
    {
        public ContextClass(DbContextOptions<ContextClass>options):base(options)
        {

        }
        public DbSet<dataClass> empl { get; set; }
    }
}
