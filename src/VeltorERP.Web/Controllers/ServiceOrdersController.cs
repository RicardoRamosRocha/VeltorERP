using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeltorERP.Domain.Entities;
using VeltorERP.Infrastructure.Data;

namespace VeltorERP.Web.Controllers;

public class ServiceOrdersController : Controller
{
    private readonly AppDbContext _context;

    public ServiceOrdersController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string? search)
    {
        var query = _context.ServiceOrders
            .Include(x => x.Customer)
            .Include(x => x.Vehicle)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x =>
                x.Customer!.Name.Contains(search) ||
                x.Vehicle!.Plate.Contains(search) ||
                x.Status.Contains(search));
        }

        var orders = await query
            .OrderByDescending(x => x.OpeningDate)
            .ToListAsync();

        ViewBag.Search = search;

        return View(orders);
    }

    public IActionResult Create()
    {
        LoadData();
        return View(new ServiceOrder());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ServiceOrder serviceOrder)
    {
        serviceOrder.Id = Guid.NewGuid();
        serviceOrder.OpeningDate = DateTime.UtcNow;
        serviceOrder.TotalAmount = serviceOrder.LaborCost + serviceOrder.PartsCost;

        _context.ServiceOrders.Add(serviceOrder);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var order = await _context.ServiceOrders
    .Include(x => x.Items)
    .FirstOrDefaultAsync(x => x.Id == id);

        if (order == null)
            return NotFound();

        ViewBag.Customers = new SelectList(
      _context.Customers.OrderBy(x => x.Name),
      "Id",
      "Name",
      order.CustomerId);

        ViewBag.Vehicles = new SelectList(
            _context.Vehicles
                .Where(v => v.CustomerId == order.CustomerId)
                .OrderBy(v => v.Plate),
            "Id",
            "Plate",
            order.VehicleId);

        return View(order);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, ServiceOrder serviceOrder)
    {
        if (id != serviceOrder.Id)
            return NotFound();

        serviceOrder.OpeningDate = DateTime.SpecifyKind(
            serviceOrder.OpeningDate,
            DateTimeKind.Utc);

        if (serviceOrder.ClosingDate.HasValue)
        {
            serviceOrder.ClosingDate = DateTime.SpecifyKind(
                serviceOrder.ClosingDate.Value,
                DateTimeKind.Utc);
        }

        var itemsTotal = await _context.ServiceOrderItems
        .Where(x => x.ServiceOrderId == serviceOrder.Id)
        .SumAsync(x => x.Total);

        serviceOrder.TotalAmount =
        serviceOrder.LaborCost +
        serviceOrder.PartsCost +
        itemsTotal;
        _context.Update(serviceOrder);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(Guid id)
    {
        var order = await _context.ServiceOrders
            .Include(x => x.Customer)
            .Include(x => x.Vehicle)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (order == null)
            return NotFound();

        return View(order);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var order = await _context.ServiceOrders.FindAsync(id);

        if (order != null)
        {
            _context.ServiceOrders.Remove(order);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
    private void LoadData()
    {
        ViewBag.Customers = new SelectList(
            _context.Customers.OrderBy(x => x.Name),
            "Id",
            "Name");

        ViewBag.Vehicles = new SelectList(
            Enumerable.Empty<SelectListItem>(),
            "Value",
            "Text");
    }



    [HttpGet]
    public async Task<JsonResult> GetVehiclesByCustomer(Guid customerId)
    {
        var vehicles = await _context.Vehicles
            .Where(v => v.CustomerId == customerId)
            .OrderBy(v => v.Plate)
            .Select(v => new
            {
                id = v.Id,
                text = v.Plate + " - " + v.Brand + " " + v.Model
            })
            .ToListAsync();

        return Json(vehicles);
    }
    public async Task<IActionResult> Print(Guid id)
    {
        var order = await _context.ServiceOrders
            .Include(x => x.Customer)
            .Include(x => x.Vehicle)
            .Include(x => x.Items)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (order == null)
            return NotFound();

        return View(order);
    }
}