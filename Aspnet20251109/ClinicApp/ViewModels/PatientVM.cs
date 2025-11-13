using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.ViewModels {
    public class PatientVM {

        public int Id { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; } = null!;

        public string NationalId { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        [Display(Name = "Date of birth")]
        public DateOnly DateOfBirth { get; set; }

        public string FirstName => FullName.Split(" ")[0];

    }
}
