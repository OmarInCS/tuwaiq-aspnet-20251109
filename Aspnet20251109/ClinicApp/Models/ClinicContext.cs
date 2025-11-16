using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Models {
    public class ClinicContext : DbContext {

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        // options passed from the Program.cs file through the method AddDbContext
        public ClinicContext(DbContextOptions options) : base(options) { }

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
