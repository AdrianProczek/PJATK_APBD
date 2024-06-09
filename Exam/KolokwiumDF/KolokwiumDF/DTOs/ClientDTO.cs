namespace KolokwiumDF.DTOs;

public class ClientDTO
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public ICollection<SubscriptionDTO> subscriptions { get; set; }
}

