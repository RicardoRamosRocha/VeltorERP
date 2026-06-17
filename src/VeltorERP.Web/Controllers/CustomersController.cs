using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeltorERP.Infrastructure.Data;
using VeltorERP.Domain.Entities;

namespace VeltorERP.Web.Controllers;

public class CustomersController : Controller
{
    private readonly AppDbContext _context;

    public CustomersController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var customers = await _context.Customers
            .OrderBy(x => x.Name)
            .ToListAsync();

        return View(customers);
    }
}