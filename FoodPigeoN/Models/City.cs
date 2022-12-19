using FoodPigeoN.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodPigeoN.Models
{
    public class City:IEntityBase
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "City Picture")]
        [Required(ErrorMessage ="City Picture Required")]
        public string CityPicture { get; set; }


        [Display(Name = "City Name")]
        [Required(ErrorMessage = "City Name Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage ="City Name must be between 3 to 50 characters")]
        public string CityName { get; set; }


        [Display(Name = "City Description")]
        [Required(ErrorMessage = "City Description Required")]
        public string Description { get; set; }


        //Relationships

        public List<Food> Foods { get; set; }

    }
}
