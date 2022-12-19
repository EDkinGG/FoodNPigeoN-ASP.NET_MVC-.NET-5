using FoodPigeoN.Data;
using FoodPigeoN.Data.Services;
using FoodPigeoN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPigeoN.Controllers
{
    public class FoodsController : Controller
    {
        private readonly IFoodsService _service;

        public FoodsController(IFoodsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allFoods = await _service.GetAllAsync( n => n.Tag);
            return View(allFoods);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allFoods = await _service.GetAllAsync(n => n.Tag);

            if( !string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allFoods.Where(n => n.FoodName.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                return View("Index",filteredResult);
            }

            return View("Index", allFoods);
        }

        //GET: Foods/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var foodsDetails = await _service.GetFoodByIdAsync(id);
            if (foodsDetails == null) return View("NotFound");
            return View(foodsDetails);
        }


        //GET: Foods/Create
        public async Task<IActionResult> Create()
        {
            var foodDropdownsData = await _service.GetNewFoodDropdownsValues();

            ViewBag.CityId = new SelectList(foodDropdownsData.Cities, "Id", "CityName");
            ViewBag.TagId = new SelectList(foodDropdownsData.Tags, "Id", "TagName");
            ViewBag.TypeId = new SelectList(foodDropdownsData.Types, "Id", "TypeName");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewFoodVM food)
        {
            if(!ModelState.IsValid)
            {
                var foodDropdownsData = await _service.GetNewFoodDropdownsValues();

                ViewBag.CityId = new SelectList(foodDropdownsData.Cities, "Id", "CityName");
                ViewBag.TagId = new SelectList(foodDropdownsData.Tags, "Id", "TagName");
                ViewBag.TypeId = new SelectList(foodDropdownsData.Types, "Id", "TypeName");

                return View(food);
            }
            await _service.AddNewFoodAsync(food);
            return RedirectToAction(nameof(Index));
        }



        //GET: Foods/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var foodDetails = await _service.GetFoodByIdAsync(id);
            if (foodDetails == null) return View("NotFound");

            var response = new NewFoodVM()
            {
                Id = foodDetails.Id,
                FoodName = foodDetails.FoodName,
                FoodPicture = foodDetails.FoodPicture,
                Price = foodDetails.Price,
                Description = foodDetails.Description,
                FoodCategory = foodDetails.FoodCategory,
                CityId = foodDetails.CityId,
                TagId = foodDetails.TagId,
                TypeId = foodDetails.TypeId
            };

            var foodDropdownsData = await _service.GetNewFoodDropdownsValues();

            ViewBag.CityId = new SelectList(foodDropdownsData.Cities, "Id", "CityName");
            ViewBag.TagId = new SelectList(foodDropdownsData.Tags, "Id", "TagName");
            ViewBag.TypeId = new SelectList(foodDropdownsData.Types, "Id", "TypeName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewFoodVM food)
        {
            if (id != food.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var foodDropdownsData = await _service.GetNewFoodDropdownsValues();

                ViewBag.CityId = new SelectList(foodDropdownsData.Cities, "Id", "CityName");
                ViewBag.TagId = new SelectList(foodDropdownsData.Tags, "Id", "TagName");
                ViewBag.TypeId = new SelectList(foodDropdownsData.Types, "Id", "TypeName");

                return View(food);
            }

            await _service.UpdateFoodAsync(food);
            return RedirectToAction(nameof(Index));
        }

    }
}
