using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using MVC_CASE.Models;
using MVC_CASE.Models.VMs;
using MVC_CASE.Contracts;
using MVC_CASE.Enums;
using System.Threading.Tasks;

namespace MVC_CASE.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICarRepository _carRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly UserManager<Kullanici> _kullaniciManager;

        public AdminController(
            ICarRepository carRepo,
            ICategoryRepository categoryRepo,
            UserManager<Kullanici> kullaniciManager)
        {
            _carRepo = carRepo;
            _categoryRepo = categoryRepo;
            _kullaniciManager = kullaniciManager;
        }

        private async Task<bool> KullaniciAdminMiAsync()
        {
            var user = await _kullaniciManager.GetUserAsync(User);
            return user != null && user.Role == UserRole.Admin;
        }

        public async Task<IActionResult> Index()
        {
            if (!await KullaniciAdminMiAsync())
                return Unauthorized();

            var cars = _carRepo.GetByCondition(c => c.Status != Status.Deleted).ToList(); 
            return View(cars);
        }

        public async Task<IActionResult> Create()
        {
            if (!await KullaniciAdminMiAsync())
                return Unauthorized();

            var model = new AdminCarVM
            {
                CategoryList = _categoryRepo.GetAll()
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminCarVM viewModel)
        {
            if (!await KullaniciAdminMiAsync())
                return Unauthorized();

            if (!ModelState.IsValid)
            {
                viewModel.CategoryList = _categoryRepo.GetAll()
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }).ToList();

                return View(viewModel);
            }

            var car = new Car
            {
                Brand = viewModel.Brand,
                Model = viewModel.Model,
                Year = viewModel.Year,
                Price = viewModel.Price,
                IsAvailable = viewModel.IsAvailable,
                ResimUrl = viewModel.ResimUrl,
                CategoryId = viewModel.CategoryId
            };

            _carRepo.Add(car);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!await KullaniciAdminMiAsync())
                return Unauthorized();

            var car = _carRepo.GetById(id);
            if (car == null)
                return NotFound();

            var model = new AdminCarVM
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year,
                Price = car.Price,
                IsAvailable = car.IsAvailable,
                ResimUrl = car.ResimUrl,
                CategoryId = car.CategoryId,
                CategoryList = _categoryRepo.GetAll()
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdminCarVM viewModel)
        {
            if (!await KullaniciAdminMiAsync())
                return Unauthorized();

            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState)
                {
                    foreach (var error in modelState.Value.Errors)
                    {
                        Console.WriteLine($"{modelState.Key}: {error.ErrorMessage}");
                    }
                }

                viewModel.CategoryList = _categoryRepo.GetAll()
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }).ToList();

                return View(viewModel);
            }

            if (!ModelState.IsValid)
            {
                viewModel.CategoryList = _categoryRepo.GetAll()
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }).ToList();
                return View(viewModel);
            }

            var car = _carRepo.GetById(viewModel.Id);
            if (car == null)
                return NotFound();

            car.Brand = viewModel.Brand;
            car.Model = viewModel.Model;
            car.Year = viewModel.Year;
            car.Price = viewModel.Price;
            car.IsAvailable = viewModel.IsAvailable;
            car.ResimUrl = viewModel.ResimUrl;
            car.CategoryId = viewModel.CategoryId;

            _carRepo.Update(car);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (!await KullaniciAdminMiAsync())
                return Unauthorized();

            var car = _carRepo.GetById(id);
            if (car == null)
                return NotFound();

            _carRepo.Delete(car);
            return RedirectToAction("Index");
        }
    }
}
