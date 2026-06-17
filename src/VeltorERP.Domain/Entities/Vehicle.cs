using System.ComponentModel.DataAnnotations;

namespace VeltorERP.Domain.Entities;

public class Vehicle
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    [Display(Name = "Placa")]
    public string Plate { get; set; } = string.Empty;

    [Display(Name = "Marca")]
    public string Brand { get; set; } = string.Empty;

    [Display(Name = "Modelo")]
    public string Model { get; set; } = string.Empty;

    [Display(Name = "Ano")]
    public int? Year { get; set; }

    [Display(Name = "Cor")]
    public string? Color { get; set; }

    [Display(Name = "Quilometragem")]
    public int? Mileage { get; set; }

    [Display(Name = "Chassi")]
    public string? Chassis { get; set; }

    [Display(Name = "Renavam")]
    public string? Renavam { get; set; }

    [Display(Name = "Combustível")]
    public string? FuelType { get; set; }

    public Customer? Customer { get; set; }

    public bool Active { get; set; } = true;
}