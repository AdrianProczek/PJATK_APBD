using Zad_6.DTOs;
using Zad_6.Repositories.Interfaces;
using Zad_6.Models;

namespace Zad_6.Repositories.Interfaces
{
    public interface IHospitalRepository
    {
        public async Task<string> AddPrescriptionAsync(PrescriptionRequestDTO request);
    }
}
