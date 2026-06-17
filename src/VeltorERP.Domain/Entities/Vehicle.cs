namespace VeltorERP.Domain.Entities;

public class Vehicle
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public string Plate { get; set; } = string.Empty;

    public string Brand { get; set; } = string.Empty;

    public string Model { get; set; } = string.Empty;

    public int? Year { get; set; }

    public string? Color { get; set; }

    public int? Mileage { get; set; }

    public Customer? Customer { get; set; }
}