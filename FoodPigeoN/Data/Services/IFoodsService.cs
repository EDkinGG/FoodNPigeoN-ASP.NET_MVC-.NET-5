using FoodPigeoN.Data.Base;
using FoodPigeoN.Data.ViewModels;
using FoodPigeoN.Models;
using System.Threading.Tasks;

namespace FoodPigeoN.Data.Services
{
    public interface IFoodsService:IEntityBaseRepository<Food>
    {
        Task<Food> GetFoodByIdAsync( int id);
        Task<NewFoodDropdownsVM> GetNewFoodDropdownsValues();
        Task AddNewFoodAsync(NewFoodVM data);

        Task UpdateFoodAsync(NewFoodVM data);

    }
}
