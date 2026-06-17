using System.ComponentModel.DataAnnotations;

namespace VeltorERP.Domain.Entities;

public class Customer
{
    public Guid Id { get; set; }

    public Guid? CompanyId { get; set; }

    [Display(Name = "Nome")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Telefone")]
    public string? Phone { get; set; }

    [Display(Name = "E-mail")]
    public string? Email { get; set; }

    [Display(Name = "CPF/CNPJ")]
    public string? Document { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Company? Company { get; set; }

    public bool Active { get; set; } = true;

    public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}