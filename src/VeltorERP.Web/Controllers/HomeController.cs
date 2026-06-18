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
    ViewBag.TotalCustomers =
        _context.Customers.Count();

    ViewBag.TotalVehicles =
        _context.Vehicles.Count();

    ViewBag.OpenOrders =
        _context.ServiceOrders.Count(x =>
            x.Status == "Em Aberto" ||
            x.Status == "Em Andamento");

    ViewBag.FinishedOrders =
        _context.ServiceOrders.Count(x =>
            x.Status == "Finalizada");

    ViewBag.TotalRevenue =
        _context.ServiceOrders
            .Where(x => x.Status == "Finalizada")
            .Sum(x => (decimal?)x.TotalAmount) ?? 0;

    return View();
}
}