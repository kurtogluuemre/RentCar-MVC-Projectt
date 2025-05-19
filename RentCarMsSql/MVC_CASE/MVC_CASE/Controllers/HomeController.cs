using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using MVC_CASE.Contracts;
using MVC_CASE.Models;
using MVC_CASE.Enums;

namespace MVC_CASE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarRepository _carRepo;
        private readonly UserManager<Kullanici> _userManager;

        public HomeController(ICarRepository carRepo, UserManager<Kullanici> userManager)
        {
            _carRepo = carRepo;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var cars = _carRepo.GetByCondition(c => c.Status != Status.Deleted).ToList(); 
            return View(cars);
        }
        
    }
}