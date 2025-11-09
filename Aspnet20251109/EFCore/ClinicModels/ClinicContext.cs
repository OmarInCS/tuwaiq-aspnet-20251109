using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.ClinicModels {
    internal class ClinicContext : DbContext {

        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                "Server=DESKTOP-2F5GL4L;Database=Clinic;Trusted_Connection=True;TrustServerCertificate=True;"
                );
        }
    }
}
