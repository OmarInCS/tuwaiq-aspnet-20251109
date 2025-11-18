using ClinicApp.Models;
using ClinicApp.Services;
using ClinicApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApp.Controllers {

    [Authorize]
    public class PatientsController : Controller {

        private readonly ClinicContext _db;

        public PatientsController(ClinicContext db, PatientsService patService, AnotherService anotherService)
        {
            _db = db;
        }


        public IActionResult Index(PatientFilterVM vm) {

            var initQuery = _db.Patients
                            .Where(p => vm.Id == null || p.Id == vm.Id)
                            .Where(p => vm.NationalId == null || p.NationalId == vm.NationalId)
                            .Where(p => vm.FullName == null || p.FullName.Contains(vm.FullName));

            vm.TotalCount = initQuery.Count();

            var patients = initQuery
                            .OrderBy(p => p.Id)
                            .Skip((vm.Page - 1) * vm.PageSize)
                            .Take(vm.PageSize)
                            .Select(p => p.ToPatientVM()).ToList();

            return View(new PatientFilteredListVM { Patients = patients, Filter = vm });
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
