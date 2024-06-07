namespace Zad_6.Models
{
    public class Prescriptions
    {
        public int IdPrescriptionId { get; set; }
        public DateTime Date {  get; set; }

        public DateTime DueDat { get; set; }

        public int IdPatient { get; set;}
        public int IdDoctor { get; set;}
        public virtual Patient IdPatientNav { get; set; }
        public virtual Doctor IdDoctorNav { get; set; }
        public virtual ICollection<PrescriptionMedicament> PrescriptionMedicament { get; set; } = new List<PrescriptionMedicament>();
       
    }
}