using AdmFagil.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdmFagil.Controllers
{
    public class FerramentasController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<FerramentasModel> ferramentas;
            return View();
        }
    }
}
