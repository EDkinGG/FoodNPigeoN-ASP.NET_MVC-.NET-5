using System.ComponentModel.DataAnnotations;

namespace FoodPigeoN.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; } 

        public Food Food { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
