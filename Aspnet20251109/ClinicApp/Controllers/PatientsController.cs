using ClinicApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApp.Controllers {
    public class PatientsController : Controller {


        public IActionResult Index() {
            var patients = Constants.Patients;
            return View(patients);
        }

        public IActionResult Details(int id) {
            var patient = Constants.Patients.Single(p => p.Id == id);
            return View(patient);
        }

    }
}
