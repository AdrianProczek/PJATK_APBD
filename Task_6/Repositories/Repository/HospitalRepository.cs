using Zad_6.DTOs;
using Zad_6.Repositories.Interfaces;
using Zad_6.Models;

namespace Zad_6.Repositories.Repository
{
    public class HospitalRepository : IHospitalRepository
    {
        private readonly ContextBoundObject _context;

        public HospitalRepository(Context context)
        {
            _context = context;
        }

        public async Task<string> AddPrescriptionAsync(PrescriptionRequestDTO request)
        {
            _context.Prescription.Add(request);
            await _context.SaveChangesAsync();

            return "success";
        }

    }
}
