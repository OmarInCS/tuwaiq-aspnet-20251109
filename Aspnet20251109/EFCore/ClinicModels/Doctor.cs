using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.ClinicModels {
    internal class Doctor {
        public int Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string? LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime HireDate { get; set; }

        [ForeignKey("Speciality")]
        public int SpecialityNum { get; set; }

        public Speciality Speciality { get; set; }
    }
}
