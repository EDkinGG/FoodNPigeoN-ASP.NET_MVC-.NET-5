using FoodPigeoN.Data.Base;
using FoodPigeoN.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodPigeoN.Models
{
    public class NewFoodVM
    {
        public int Id { get; set; }

        [Display(Name = "Food Name")]
        [Required(ErrorMessage = "Food Name Required")]
        public string FoodName { get; set; }


        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description Required")]
        public string Description { get; set; }


        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price Required")]
        public double Price { get; set; }


        [Display(Name = "Food Picture")]
        [Required(ErrorMessage = "Food Picture Required")]
        public string FoodPicture { get; set; }


        [Display(Name = "Select a Food Category")]
        [Required(ErrorMessage = "Food Category Required")]
        public FoodCategory FoodCategory { get; set; }


        [Display(Name = "Select a City")]
        [Required(ErrorMessage = "City is Required")]
        public int CityId { get; set; }


        [Display(Name = "Select a Food Type")]
        [Required(ErrorMessage = "Food Type is Required")]
        public int TypeId { get; set; }


        [Display(Name = "Select a Food Tag")]
        [Required(ErrorMessage = "Food Tag is Required")]
        public int TagId { get; set; }

    }
}
