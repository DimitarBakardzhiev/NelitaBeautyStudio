namespace NelitaBeautyStudio.Web.ViewModels.Manage
{
    using System.ComponentModel.DataAnnotations;

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Текуща парола")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} трябва да бъде поне {2} символа.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Нова парола")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Потвърждение на новата парола")]
        [Compare("NewPassword", ErrorMessage = "Новата парола и потвърждението ѝ са различни.")]
        public string ConfirmPassword { get; set; }
    }
}