using System.ComponentModel.DataAnnotations;

namespace VeltorERP.Domain.Entities;

public class ServiceOrder
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public Guid VehicleId { get; set; }

    [Display(Name = "Data de Abertura")]
    public DateTime OpeningDate { get; set; } = DateTime.UtcNow;

    [Display(Name = "Data de Fechamento")]
    public DateTime? ClosingDate { get; set; }

    [Display(Name = "Reclamação do Cliente")]
    public string? Complaint { get; set; }

    [Display(Name = "Diagnóstico")]
    public string? Diagnosis { get; set; }

    [Display(Name = "Serviço Executado")]
    public string? ServicePerformed { get; set; }

    [Display(Name = "Quilometragem")]
    public int? Mileage { get; set; }

    [Display(Name = "Mão de Obra")]
    public decimal LaborCost { get; set; }

    [Display(Name = "Peças")]
    public decimal PartsCost { get; set; }

    [Display(Name = "Total")]
    public decimal TotalAmount { get; set; }

    [Display(Name = "Status")]
    public string Status { get; set; } = "Em Aberto";

    public Customer? Customer { get; set; }

    public Vehicle? Vehicle { get; set; }
}