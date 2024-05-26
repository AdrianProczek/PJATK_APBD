namespace Zad_6.Models
{
    public class Prescriptions
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}