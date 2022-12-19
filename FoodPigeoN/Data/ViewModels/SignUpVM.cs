using System.ComponentModel.DataAnnotations;

namespace FoodPigeoN.Data.ViewModels
{
    public class SignUpVM
    {
        [Display(Name = "Full name")]
        [Required(ErrorMessage = "Full name is required")]
        public string FullName { get; set; }


        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string EmailAddress { get; set; }


        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address required")]
        public string Address { get; set; }


        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number required")]
        public string PhoneNumber { get; set; }


        [Display(Name = "User name")]
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }


        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
