using ClinicApp.Models;
using ClinicApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApp.Controllers {
    public class PatientsController : Controller {


        public IActionResult Index() {
            var patients = Constants.Patients.Select(p => p.ToPatientVM()).ToList();
            return View(patients);
        }

        public IActionResult Details(int id) {
            var patient = Constants.Patients.Single(p => p.Id == id).ToPatientVM();
            return View(patient);
        }

        public IActionResult Register() {
            return View();
        }

        [HttpPost]
        public IActionResult Register(PatientCreateVM vm) {
            
            if (!ModelState.IsValid) {
                return View(vm);
            }

            var p = vm.ToModel();
            p.Id = Constants.Patients.Select(p => p.Id).Max() + 1;
            Constants.Patients.Add(p);
            return RedirectToAction("Details", new { id = p.Id });
        }

    }
}
