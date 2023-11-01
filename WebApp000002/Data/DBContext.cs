using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp000002.Models;

namespace WebApp000002.Data
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }
            public DbSet<WebApp000002.Models.Consulta> Consulta { get; set; } = default!;
            public DbSet<WebApp000002.Models.paciente> paciente { get; set; } = default!;


    }
}
