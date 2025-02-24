using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCteste.Models;

namespace MVCteste.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options){}

        public DbSet<Aluno> Alunos { get; set; }

        internal object Add<T>()
        {
            throw new NotImplementedException();
        }
    }
}