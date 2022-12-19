using System.ComponentModel.DataAnnotations;

namespace FoodPigeoN.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address is Requird")]
        public string EmailAddress { get; set; }


        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
