using FoodPigeoN.Data.Base;
using FoodPigeoN.Models;

namespace FoodPigeoN.Data.Services
{
    public class TagsService : EntityBaseRepository<Tag>, ITagsService
    {
        public TagsService(AppDbContext context) : base(context) 
        {
        }

    }
}
