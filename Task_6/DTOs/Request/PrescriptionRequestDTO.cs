using Zad_6.DTOs.Response;

namespace Zad_6.DTOs.Request
{
    public class PrescriptionRequestDTO
    {
        public PatientDTO Patient { get; set; }
        public List<MedicamentDTO> Medicaments { get; set; }
        public DateTime Date { get; set; }
        public string DueDate { get; set; }
    }
}
