using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pessoalzinho.Models;

namespace Pessoalzinho.Data
{
    public class PessoalzinhoContext : DbContext
    {
        public PessoalzinhoContext (DbContextOptions<PessoalzinhoContext> options)
            : base(options)
        {
        }

        public DbSet<Pessoalzinho.Models.Gente> Gente { get; set; }
    }
}
