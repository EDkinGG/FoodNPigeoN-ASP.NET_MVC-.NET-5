using FoodPigeoN.Data.Base;
using FoodPigeoN.Data.ViewModels;
using FoodPigeoN.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPigeoN.Data.Services
{
    public class FoodsService:EntityBaseRepository<Food>, IFoodsService
    {
        private readonly AppDbContext _context;
        public FoodsService( AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewFoodAsync(NewFoodVM data)
        {
            var newFood = new Food()
            {
                FoodName = data.FoodName,
                FoodPicture = data.FoodPicture,
                Price = data.Price,
                Description = data.Description,
                FoodCategory = data.FoodCategory,
                CityId = data.CityId,
                TagId = data.TagId,
                TypeId = data.TypeId
            };
            await _context.Foods.AddAsync(newFood);
            await _context.SaveChangesAsync();
        }

        public async Task<Food> GetFoodByIdAsync(int id)
        {
            var foodDetails = await _context.Foods
                .Include(tg => tg.Tag)
                .Include(tp => tp.Type)
                .Include(ct => ct.City)
                .FirstOrDefaultAsync(n => n.Id == id);
            return foodDetails;
        }

        public async Task<NewFoodDropdownsVM> GetNewFoodDropdownsValues()
        {
            var response = new NewFoodDropdownsVM()
            {
                Cities = await _context.Cities.OrderBy(n => n.CityName).ToListAsync(),
                Tags = await _context.Tags.OrderBy(n => n.TagName).ToListAsync(),
                Types = await _context.Types.OrderBy(n => n.TypeName).ToListAsync()
            };
            return response;

        }

        public async Task UpdateFoodAsync(NewFoodVM data)
        {
            var dbFood = await _context.Foods.FirstOrDefaultAsync(n => n.Id == data.Id);

            if( dbFood != null )
            {

                dbFood.FoodName = data.FoodName;
                dbFood.FoodPicture = data.FoodPicture;
                dbFood.Price = data.Price;
                dbFood.Description = data.Description;
                dbFood.FoodCategory = data.FoodCategory;
                dbFood.CityId = data.CityId;
                dbFood.TagId = data.TagId;
                dbFood.TypeId = data.TypeId;
                await _context.SaveChangesAsync();
            }

        }
    }
}
