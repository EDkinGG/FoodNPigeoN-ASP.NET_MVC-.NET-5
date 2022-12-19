using FoodPigeoN.Data;
using FoodPigeoN.Data.Services;
using FoodPigeoN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPigeoN.Controllers
{
    public class TypesController : Controller
    {
        private readonly ITypesService _service;

        public TypesController(ITypesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allTypes = await _service.GetAllAsync();
            return View(allTypes);
        }

        //GET: tags/details/1
        public async Task<IActionResult> Details(int id)
        {
            var typesDetails = await _service.GetByIdAsync(id);
            if (typesDetails == null) return View("NotFound");
            return View(typesDetails);
        }

        //GET: tags/create/1
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("TypePicture,TypeName,Description")] Typee type)
        {
            if (!ModelState.IsValid) return View(type);

            await _service.AddAsync(type);
            return RedirectToAction(nameof(Index));
        }

        //GET: tags/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var typeDetails = await _service.GetByIdAsync(id);
            if (typeDetails == null) return View("NotFund");
            return View(typeDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypePicture,TypeName,Description")] Typee type)
        {
            if (!ModelState.IsValid) return View(type);

            if (id == type.Id)
            {
                await _service.UpdateAsync(id, type);
                return RedirectToAction(nameof(Index));
            }
            return View(type);
        }



        //GET: tags/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var typeDetails = await _service.GetByIdAsync(id);
            if (typeDetails == null) return View("NotFund");
            return View(typeDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeDetails = await _service.GetByIdAsync(id);
            if (typeDetails == null) return View("NotFund");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
