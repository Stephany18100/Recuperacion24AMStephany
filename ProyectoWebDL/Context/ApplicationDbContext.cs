using Microsoft.EntityFrameworkCore;
using ProyectoWebDL.Models.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ProyectoWebDL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }


        public virtual DbSet<Articulo> Articulos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
