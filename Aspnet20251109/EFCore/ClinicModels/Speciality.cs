using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.ClinicModels {
    internal class Speciality {

        [Key]
        public int Code { get; set; }

        public string Name { get; set; }


        public List<Doctor> Doctors { get; set; }

    }
}
