using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProyectoWebDL.Models.Entities;
using ProyectoWebDL.Services.IServices;

namespace ProyectoWebDL.Controllers
{
    public class ArticuloController : Controller
    {

        private readonly IArticuloServices _articuloServices;
        public ArticuloController(IArticuloServices articuloServices)
        {
            _articuloServices = articuloServices;
        }

        [HttpGet]

        public async Task<IActionResult> Index()
        {
            try
            {

                return View(await _articuloServices.GetArticulos());

            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error" + ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear([FromForm]Articulo request)
        {
            try
            {
                var response = _articuloServices.CrearArticulo(request);
              
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                throw new Exception("Error"+ ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var response = await _articuloServices.GetByIdArticulo(id);
            return View(response);
        }

        [HttpPost]
        public IActionResult Editar(Articulo request)
        {
            var response = _articuloServices.EditarArticulo(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            bool result = _articuloServices.EliminarArticulo(id);
            if(result = true)
            {
                return Json(new { succes = true });
            }
            else
            {
                return Json(new { succes = false });
            }
        }

        [HttpGet]

        public async Task<IActionResult> IndexCopia()
        {
            try
            {


                return View(await _articuloServices.GetArticulos());


            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error" + ex.Message);
            }
        }
    }
}
