using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundaEvaluacion.Shared.Datos.Entidades
{
    public class dbContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public dbContext(DbContextOptions<dbContext> options)
                  : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            var cascadeFKs = modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            }

            base.OnModelCreating(modelBuilder);

        }


    }
}
