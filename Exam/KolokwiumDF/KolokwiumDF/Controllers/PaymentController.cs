using KolokwiumDF.Contexts;
using KolokwiumDF.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace KolokwiumDF.Controllers;


[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly AppDbContext _context;
    public PaymentController(AppDbContext context)
    {
        _context = context;
    }



    [HttpPost]
    public async Task<IActionResult> AddPayment(int idClient, int idSubcription, [FromBody] Payment payment)
    {
        var sub = await _context.Subscriptions.FindAsync(idSubcription);
        if (sub == null)
        {
            return BadRequest("subskrypcja nie istnieje.");
        }
        else if (sub.EndTime < DateTime.Now)
        {
            return BadRequest("subskrypcja wygasla.");
        }

        var client = await _context.Clients.FindAsync(idClient);
        if (client == null)
        {
            return BadRequest("klient nie istnieje.");
        }

        Payment created = new Payment
        {
            Date = DateTime.Now,
            IdClient = client.IdClient,
            IdSubscription = idSubcription
        };
        return Ok(created.IdPayment);
    }


}
