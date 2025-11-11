using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.ClinicModels {
    internal class ClinicContext : DbContext {

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(
                "Server=DESKTOP-2F5GL4L;Database=Clinic;Trusted_Connection=True;TrustServerCertificate=True;"
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doctor>()
                .Property(d => d.LastName)
                .HasDefaultValue("Alfulani");

            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Speciality)
                .WithMany(s => s.Doctors)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .Property(a => a.CreatedAt)
                .HasDefaultValueSql("GetDate()");

            modelBuilder.Entity<Speciality>()
                .HasData([
                    new Speciality { Code = 1, Name = "Orthopidcs"},
                    new Speciality { Code = 2, Name = "Dental" },
                    new Speciality { Code = 3, Name = "Pediatric" }
                    ]);
        }
    }
}
