using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteSquadra.Models;

    public class TesteSquadraContext : DbContext
    {
        public TesteSquadraContext (DbContextOptions<TesteSquadraContext> options)
            : base(options)
        {
        }

        public DbSet<BlogPost> BlogPost { get; set; }
        public DbSet<Sistemas> Sistemas { get; set; }
}
