using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeltorERP.Domain.Entities;
using VeltorERP.Infrastructure.Data;

namespace VeltorERP.Web.Controllers;

public class ServiceOrderItemsController : Controller
{
    private readonly AppDbContext _context;

    public ServiceOrderItemsController(AppDbContext context)
    {
        _context = context;
    }

public IActionResult Create(Guid serviceOrderId)
{
    var item = new ServiceOrderItem
    {
        ServiceOrderId = serviceOrderId
    };

    return View(item);
}

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create(ServiceOrderItem item)
{
    item.Id = Guid.NewGuid();
    item.Total = item.Quantity * item.UnitPrice;

    _context.ServiceOrderItems.Add(item);
    await _context.SaveChangesAsync();

    var serviceOrder = await _context.ServiceOrders
        .Include(x => x.Items)
        .FirstOrDefaultAsync(x => x.Id == item.ServiceOrderId);

if (serviceOrder != null)
{
    await _context.Entry(serviceOrder)
        .Collection(x => x.Items)
        .LoadAsync();

    serviceOrder.TotalAmount =
        serviceOrder.LaborCost +
        serviceOrder.PartsCost +
        serviceOrder.Items.Sum(x => x.Total);

    _context.ServiceOrders.Update(serviceOrder);

    await _context.SaveChangesAsync();
}

    return RedirectToAction(
        "Edit",
        "ServiceOrders",
        new { id = item.ServiceOrderId });

}

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Delete(Guid id)
{
    var item = await _context.ServiceOrderItems.FindAsync(id);

    if (item == null)
        return NotFound();

    var serviceOrderId = item.ServiceOrderId;

    _context.ServiceOrderItems.Remove(item);
    await _context.SaveChangesAsync();

    var serviceOrder = await _context.ServiceOrders
        .Include(x => x.Items)
        .FirstOrDefaultAsync(x => x.Id == serviceOrderId);

    if (serviceOrder != null)
    {
        serviceOrder.TotalAmount =
            serviceOrder.LaborCost +
            serviceOrder.PartsCost +
            serviceOrder.Items.Sum(x => x.Total);

        _context.ServiceOrders.Update(serviceOrder);
        await _context.SaveChangesAsync();
    }

    return RedirectToAction("Edit", "ServiceOrders", new { id = serviceOrderId });
}
}