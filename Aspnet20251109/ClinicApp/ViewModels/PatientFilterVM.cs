using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.ViewModels {
    public class PatientFilterVM {

        public int? Id { get; set; }

        [Display(Name = "Full Name")]
        public string? FullName { get; set; }

        public string? NationalId { get; set; }


    }
}
