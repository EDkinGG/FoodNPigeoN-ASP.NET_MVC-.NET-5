using FoodPigeoN.Data.Base;
using FoodPigeoN.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPigeoN.Data.Services
{
    public class CitiesService :EntityBaseRepository<City>, ICitiesService
    {
        public CitiesService(AppDbContext context) : base(context) { }
    
    }
}
