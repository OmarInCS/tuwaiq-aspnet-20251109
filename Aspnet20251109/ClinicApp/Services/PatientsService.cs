using ClinicApp.Models;

namespace ClinicApp.Services {
    public class PatientsService {

        private static int Count { get; set; }

        public PatientsService(AnotherService anotherService, ClinicContext context)
        {
            Count++;
            Console.WriteLine("PatientsService: " + Count);
        }
    }
}
