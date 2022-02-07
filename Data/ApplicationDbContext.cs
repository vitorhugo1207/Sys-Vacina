using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgramaEstagio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaEstagio.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //  Setting DB for the script
        public DbSet<Person> Person { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Vaccine> Vaccine { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // overwritte the method
        {
            modelBuilder.Entity<Vaccine>(entity =>
            {
                entity.ToTable("Vaccine");
                entity.Property(p => p.VaccinePrice).HasPrecision(18, 2); // Eightteen house Left decimal and two house Right decimal
                entity.HasOne(p => p.Person).WithMany(p => p.Vaccines).HasForeignKey(p => p.PersonID).IsRequired().OnDelete(DeleteBehavior.NoAction); 
                // One person can have many vaccines. PersonID identificator. 
            });
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");
                entity.HasOne(p => p.Person).WithMany(p => p.Address).HasForeignKey(p => p.PersonID).IsRequired().OnDelete(DeleteBehavior.NoAction);
                // One person can have many vaccines. PersonID identificator. 
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
