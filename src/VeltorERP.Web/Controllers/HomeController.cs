using Microsoft.AspNetCore.Mvc;
using VeltorERP.Infrastructure.Data;

namespace VeltorERP.Web.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        ViewBag.TotalCustomers = _context.Customers.Count();
        ViewBag.TotalVehicles = _context.Vehicles.Count();

        return View();
    }
}