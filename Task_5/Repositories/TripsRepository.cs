using Zadanie7.Interfaces;
using Zadanie7.Models;
using Zadanie7.Models.DTOs;

namespace Zadanie7.Repositories
{
    public class TripsRepository : ITripsRepository
    {
        private readonly APBDZadanie7Contex _contex;

        public TripsRepository(APBDZadanie7Contex contex)
        {
            _contex = contex;
        }
        public Task<IEnumerable<TripDTO>> GetTripsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
