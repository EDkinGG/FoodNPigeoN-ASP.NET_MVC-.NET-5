using FoodPigeoN.Data.Base;
using FoodPigeoN.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodPigeoN.Models
{
    public class Food:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string FoodName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string FoodPicture { get; set; }
        public FoodCategory FoodCategory { get; set; }

        //Relationships
        //City
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }

        //Type
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public Typee Type { get; set; }

        //Tag
        public int TagId { get; set; }
        [ForeignKey("TagId")]
        public Tag Tag { get; set; }


    }
}
