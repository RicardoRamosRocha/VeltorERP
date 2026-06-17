namespace VeltorERP.Domain.Entities;

public class Customer
{
    public Guid Id { get; set; }

    public Guid? CompanyId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Document { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Company? Company { get; set; }

    public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}