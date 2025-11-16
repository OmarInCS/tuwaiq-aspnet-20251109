using ClinicApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Models {
    public class Patient {

        public int Id { get; set; }

        [MaxLength(150)]
        public string FullName { get; set; } = null!;

        [MaxLength(10)]
        public string NationalId { get; set; } = null!;

        [MaxLength(150)]
        public string Email { get; set; } = null!;

        [MaxLength(10), MinLength(10)]
        public string PhoneNumber { get; set; } = null!;

        //[Column(TypeName = "date")]
        public DateOnly DateOfBirth { get; set; }

        public List<Appointment> Appointments { get; set; } = new();


        public PatientVM ToPatientVM() {
            return new PatientVM {
                Id = Id,
                FullName = FullName,
                NationalId = NationalId,
                Email = Email,
                PhoneNumber = PhoneNumber,
                DateOfBirth = DateOfBirth,
            };
        }

        public PatientUpdateVM ToPatientUpdateVM() {
            return new PatientUpdateVM {
                FullName = FullName,
                NationalId = NationalId,
                Email = Email,
                PhoneNumber = PhoneNumber,
                DateOfBirth = DateOfBirth,
            };
        }

    }
}
