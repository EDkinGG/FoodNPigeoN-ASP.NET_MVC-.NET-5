using FoodPigeoN.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodPigeoN.Models
{
    public class Typee:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Type Picture")]
        [Required(ErrorMessage = "Type Picture Required")]
        public string TypePicture { get; set; }



        [Display(Name = "Type Name")]
        [Required(ErrorMessage = "Type Name Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Type Name must be between 3 to 50 characters")]
        public string TypeName { get; set; }



        [Display(Name = "Description")]
        [Required(ErrorMessage = "Type Description Required")]
        public string Description { get; set; }



        //Relationships
        public List<Food> Foods { get; set; }
    }
}
