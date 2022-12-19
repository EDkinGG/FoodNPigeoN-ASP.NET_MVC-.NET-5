using FoodPigeoN.Data.Base;
using FoodPigeoN.Models;

namespace FoodPigeoN.Data.Services
{
    public class TypesService:EntityBaseRepository<Typee>, ITypesService
    {
        public TypesService(AppDbContext context) : base(context)
        {

        }
    }
}
