namespace ClinicApp.ViewModels {
    public class PatientFilteredListVM {

        public List<PatientVM> Patients { get; set; }

        public PatientFilterVM Filter { get; set; } = new ();

    }
}
