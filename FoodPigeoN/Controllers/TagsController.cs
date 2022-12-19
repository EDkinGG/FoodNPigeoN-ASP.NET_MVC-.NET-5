using FoodPigeoN.Data;
using FoodPigeoN.Data.Services;
using FoodPigeoN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FoodPigeoN.Controllers
{
    public class TagsController : Controller
    {
        private readonly ITagsService _service;

        public TagsController(ITagsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allTags = await _service.GetAllAsync();
            return View(allTags);
        }

        //GET: tags/details/1
        public async Task<IActionResult> Details(int id)
        {
            var tagsDetails = await _service.GetByIdAsync(id);
            if (tagsDetails == null) return View("NotFound");
            return View(tagsDetails);
        }

        //GET: tags/create/1
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("TagPicture,TagName,Description")]Tag tag)
        {
            if (!ModelState.IsValid) return View(tag);

            await _service.AddAsync(tag);
            return RedirectToAction(nameof(Index));
        }

        //GET: tags/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var tagDetails = await _service.GetByIdAsync(id);
            if (tagDetails == null) return View("NotFund");
            return View(tagDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TagPicture,TagName,Description")] Tag tag)
        {
            if (!ModelState.IsValid) return View(tag);

            if(id == tag.Id )
            {
                await _service.UpdateAsync(id, tag);
                return RedirectToAction(nameof(Index));
            }
            return View(tag); 
        }



        //GET: tags/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var tagDetails = await _service.GetByIdAsync(id);
            if (tagDetails == null) return View("NotFund");
            return View(tagDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tagDetails = await _service.GetByIdAsync(id);
            if (tagDetails == null) return View("NotFund");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
