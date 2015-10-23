namespace NelitaBeautyStudio.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Полето {0} трябва да бъде поне {2} символа.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Потвърждение на паролата")]
        [Compare("Password", ErrorMessage = "Паролата и потвърждението са различни.")]
        public string ConfirmPassword { get; set; }
    }
}