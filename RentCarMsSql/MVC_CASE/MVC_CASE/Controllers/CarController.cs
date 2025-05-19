using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_CASE.Contracts;
using MVC_CASE.Models;

namespace MVC_CASE.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public IActionResult Reserve(int id)
        {
            var car = _carRepository.GetById(id);
            if (car == null)
                return NotFound();

            ViewBag.Message = $"{car.Brand} {car.Model} başarıyla kiralandı";
            return View("ReserveSuccess");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Kirala([FromBody] KiralaRequestModel model)
        {
            return Ok(); 
        }
    }
    public class KiralaRequestModel
    {
        public int CarId { get; set; }
    }

}
