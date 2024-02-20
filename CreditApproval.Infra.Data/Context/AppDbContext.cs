using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using CreditApproval.Domain.Entities;

namespace CreditApproval.Infra.Data
{
    [ExcludeFromCodeCoverage]
    public class AppDbContext : DbContext
    {
        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<FinancingEntity> Financings { get; set; }
        public DbSet<InstallmentEntity> Installments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configurações
            //configurações para entidade de relacionamento
            modelBuilder.Entity<ClientEntity>()
                .HasKey(x => new { x.Id });

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
         
        }
    }
}
