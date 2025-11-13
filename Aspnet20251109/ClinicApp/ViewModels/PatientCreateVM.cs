using ClinicApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.ViewModels {
    public class PatientCreateVM {

        [MaxLength(150)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = null!;

        [MaxLength(10), RegularExpression("[12]\\d{9}", ErrorMessage = "The input should be in the form 1xxxxxxxxx or 2xxxxxxx")]
        public string NationalId { get; set; } = null!;

        [MaxLength(150), EmailAddress]
        public string Email { get; set; } = null!;

        [MaxLength(10), MinLength(10)]
        public string PhoneNumber { get; set; } = null!;

        //[Column(TypeName = "date")]
        [Display(Name = "Date of birth")]
        public DateOnly DateOfBirth { get; set; }


        public Patient ToModel() {
            return new Patient { 
                FullName = FullName, 
                NationalId = NationalId, 
                Email = Email, 
                PhoneNumber = PhoneNumber, 
                DateOfBirth = DateOfBirth 
            };
        }
    }
}
