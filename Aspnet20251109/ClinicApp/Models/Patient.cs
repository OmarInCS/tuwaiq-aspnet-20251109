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

        [MaxLength(10), RegularExpression("[12]\\d{9}")]
        public string NationalId { get; set; } = null!;

        [MaxLength(150), EmailAddress]
        public string Email { get; set; } = null!;

        [MaxLength(10), MinLength(10)]
        public string PhoneNumber { get; set; } = null!;

        //[Column(TypeName = "date")]
        public DateOnly DateOfBirth { get; set; }

        public List<Appointment> Appointments { get; set; } = new();

    }
}
