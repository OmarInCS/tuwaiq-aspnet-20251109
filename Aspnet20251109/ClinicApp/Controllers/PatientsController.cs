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

        public IActionResult Register() {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Patient p) {
            
            if (!ModelState.IsValid) {
                return View(p);
            }

            p.Id = Constants.Patients.Select(p => p.Id).Max() + 1;
            Constants.Patients.Add(p);
            return RedirectToAction("Details", new { id = p.Id });
        }

    }
}
