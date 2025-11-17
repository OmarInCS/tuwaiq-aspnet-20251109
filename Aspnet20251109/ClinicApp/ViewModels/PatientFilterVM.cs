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


        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 2;
        public int TotalCount { get; set; }

        public int PageCount => (int) Math.Ceiling((double) TotalCount / PageSize);
    }
}
