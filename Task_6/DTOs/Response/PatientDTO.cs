using Zad_6.Models;

namespace Zad_6.DTOs.Response
{
    public class PatientDTO
    {
        public int IdPatient { get; set; }

        public string FirstName { get; set;}

        public string LastName { get; set;}
        
        public DateTime BirthDate { get; set; }

    }
}
