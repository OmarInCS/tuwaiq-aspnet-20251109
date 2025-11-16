using ClinicApp.Models;
using ClinicApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApp.Controllers {
    public class PatientsController : Controller {

        private readonly ClinicContext _db;

        public PatientsController(ClinicContext db)
        {
            _db = db;
        }


        public IActionResult Index(PatientFilteredListVM vm) {

            var patients = _db.Patients
                            .Where(p => vm.Filter.Id == null || p.Id == vm.Filter.Id)
                            .Where(p => vm.Filter.NationalId == null || p.NationalId == vm.Filter.NationalId)
                            .Where(p => vm.Filter.FullName == null || p.FullName.Contains(vm.Filter.FullName))
                            .Select(p => p.ToPatientVM()).ToList();

            return View(new PatientFilteredListVM { Patients = patients, Filter = vm.Filter });
        }

        public IActionResult Details(int id) {
            var patient = _db.Patients.Single(p => p.Id == id).ToPatientVM();
            return View(patient);
        }

        public IActionResult Register() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(PatientCreateVM vm) {
            
            if (!ModelState.IsValid) {
                return View(vm);
            }

            var p = vm.ToModel();            
            _db.Patients.Add(p);
            _db.SaveChanges();
            return RedirectToAction("Details", new { id = p.Id });
        }


        public IActionResult Update(int id) {
            var patient = _db.Patients.Single(p => p.Id == id).ToPatientUpdateVM();
            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PatientUpdateVM vm) {

            if (!ModelState.IsValid) {
                return View(vm);
            }

            var patient = _db.Patients.Single(p => p.Id == id);
            patient.FullName = vm.FullName;
            patient.PhoneNumber = vm.PhoneNumber;
            patient.Email = vm.Email;
            patient.DateOfBirth = vm.DateOfBirth;
            patient.NationalId = vm.NationalId;

            _db.SaveChanges();

            return RedirectToAction("Details", new { id });
        }


        public IActionResult Delete(int id) {
            var patient = _db.Patients.Single(p => p.Id == id);
            _db.Patients.Remove(patient);
            _db.SaveChanges();

            return Ok();
        }
    }
}
