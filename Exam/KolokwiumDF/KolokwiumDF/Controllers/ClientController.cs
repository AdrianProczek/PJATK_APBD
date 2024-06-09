using KolokwiumDF.Contexts;
using KolokwiumDF.DTOs;
using KolokwiumDF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace KolokwiumDF.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly AppDbContext _context;
    public ClientController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetClientData(int id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client == null)
        {
            return NotFound("klient nie istnieje.");
        }

        List<Sale> all_sales = await _context.Sales.Where(sales => sales.IdClient == id).ToListAsync();

        List<SubscriptionDTO> SubscriptionDTO = new List<SubscriptionDTO>();
        foreach (var s in all_sales)
        {
            var total_amm = s.Subscription.RenewalPeriod * s.Subscription.Price;
            SubscriptionDTO.Add(new SubscriptionDTO
            {
                IdSubscription = s.Subscription.IdSubscription,
                Name = s.Subscription.Name,
                TotalPaidAmount = (double)total_amm
            });;
        }

        ClientDTO ClientDTO = new ClientDTO
        {
            firstName = client.FirstName,
            lastName = client.LastName,
            email = client.Email,
            phone = client.Phone,
            subscriptions = SubscriptionDTO
        };

        return Ok(ClientDTO);
    }



}
