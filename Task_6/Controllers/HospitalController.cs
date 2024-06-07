using Zad_6.DTOs.Request;
using Zad_6.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Zad_6.Controllers
{
    [ApiController]
    [Route("api/hospital")]
    public class HospitalController : Controller
    {
        private readonly IHospitalRepository : ControllerBase

        public HospitalController(IHospitalRepository repository) 
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> AddPrescription([FromBody] PrescriptionRequestDTO request)
        {
            var test = await _repository.AddPrescriptionAsync(request);
            return Ok(test);
        }
    }
}