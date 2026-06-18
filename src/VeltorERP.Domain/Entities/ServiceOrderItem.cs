using System.ComponentModel.DataAnnotations;

namespace VeltorERP.Domain.Entities;

public class ServiceOrderItem
{
    public Guid Id { get; set; }

    public Guid ServiceOrderId { get; set; }

    [Display(Name = "Descrição")]
    public string Description { get; set; } = string.Empty;

    [Display(Name = "Quantidade")]
    public decimal Quantity { get; set; }

    [Display(Name = "Valor Unitário")]
    public decimal UnitPrice { get; set; }

    [Display(Name = "Total")]
    public decimal Total { get; set; }

    public ServiceOrder? ServiceOrder { get; set; }
}