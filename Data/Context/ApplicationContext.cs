using System;
using System.Linq;
using System.Threading.Tasks;
using Data.Mappings;
using Domain.Entidades;
using Domain.Entidades.Base;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options){}

        public DbSet<Usuario> Usuarios { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuariosMaping());
        }
        
        public override int SaveChanges()
        {
            if (!ChangeTracker.Entries().Any())
                return 0;
            
            AddDateTimes();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            AddDateTimes();
            return await base.SaveChangesAsync();
        }
        
        private void AddDateTimes()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified)).ToList();

            entities.ForEach(e =>
            {
                if (e.State == EntityState.Added)
                    ((Usuario) e.Entity).DataCadastro = DateTime.UtcNow;
                else
                    ((Usuario)e.Entity).DataAtualizacao = DateTime.UtcNow;
            });
        }
    }
}