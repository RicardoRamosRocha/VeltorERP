using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeltorERP.Domain.Entities;
using VeltorERP.Infrastructure.Data;

namespace VeltorERP.Web.Controllers;

public class VehiclesController : Controller
{
    private readonly AppDbContext _context;

    public VehiclesController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var vehicles = await _context.Vehicles
            .Include(v => v.Customer)
            .OrderBy(v => v.Plate)
            .ToListAsync();

        return View(vehicles);
    }

    public IActionResult Create()
    {
        LoadCustomers();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Vehicle vehicle)
    {
        vehicle.Id = Guid.NewGuid();

        _context.Vehicles.Add(vehicle);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);

        if (vehicle == null)
            return NotFound();

        LoadCustomers();
        return View(vehicle);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, Vehicle vehicle)
    {
        if (id != vehicle.Id)
            return NotFound();

        _context.Update(vehicle);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        var vehicle = await _context.Vehicles
            .Include(v => v.Customer)
            .FirstOrDefaultAsync(v => v.Id == id);

        if (vehicle == null)
            return NotFound();

        return View(vehicle);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);

        if (vehicle != null)
        {
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private void LoadCustomers()
    {
        ViewBag.Customers = new SelectList(
            _context.Customers.OrderBy(c => c.Name),
            "Id",
            "Name");
    }
}