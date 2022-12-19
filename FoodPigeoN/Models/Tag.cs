using FoodPigeoN.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodPigeoN.Models
{
    public class Tag:IEntityBase
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Tag Picture")]
        [Required(ErrorMessage = "Tag Picture Required")]
        public string TagPicture { get; set; }



        [Display(Name = "Tag Name")]
        [Required(ErrorMessage = "Tag Name Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Tag Name must be between 3 to 50 characters")]
        public string TagName { get; set; }



        [Display(Name = "Decription")]
        [Required(ErrorMessage = "Tag Description Required")]
        public string Description { get; set; }

        //Relationships
        public List<Food> Foods { get; set; }
    }
}
