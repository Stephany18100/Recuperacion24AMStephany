using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoWebDL.Context;
using ProyectoWebDL.Models;
using ProyectoWebDL.Services.IServices;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ProyectoWebDL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticuloServices _articuloServices;
        private readonly ApplicationDbContext _context;

        public HomeController(IArticuloServices articuloServices, ApplicationDbContext context)
        {
            _articuloServices = articuloServices;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Page()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            List<Models.Entities.Articulo> response = await _articuloServices.GetArticulos();
            return View(response);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
