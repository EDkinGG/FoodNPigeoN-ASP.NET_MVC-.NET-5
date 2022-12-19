using FoodPigeoN.Models;
using System.Collections.Generic;

namespace FoodPigeoN.Data.ViewModels
{
    public class NewFoodDropdownsVM
    {
        public NewFoodDropdownsVM()
        {
            Cities = new List<City>();
            Types = new List<Typee>();
            Tags = new List<Tag>();
        }

        public List<City> Cities { get; set; }
        public List<Typee> Types { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
