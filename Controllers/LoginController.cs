using Microsoft.AspNetCore.Mvc;
using MVCteste.Data;
using MVCteste.Models;

namespace MVCteste.Controllers
{
    public class LoginController : Controller
    {
       public readonly ApplicationDbContext _contexto;

        public LoginController(ApplicationDbContext contexto)
        {
                _contexto = contexto;
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}