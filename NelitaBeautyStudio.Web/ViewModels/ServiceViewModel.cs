namespace NelitaBeautyStudio.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using NelitaBeautyStudio.Common;

    public class ServiceViewModel
    {
        [Display(Name = "Услуга")]
        [Required(ErrorMessage = "Полето {0} е задължително")]
        [StringLength(
            GlobalConstants.TextFieldLengthMax,
            ErrorMessage = "Полето {0} трябва да бъде между {2} и {1} символа!",
            MinimumLength = GlobalConstants.TextFieldLengthMin)]
        public string Type { get; set; }

        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Полето {0} е задължително")]
        [Range(GlobalConstants.PriceMinimum, GlobalConstants.PriceMaximum, ErrorMessage = "Полето {0} трябва да бъде между {1} и {2} лева!")]
        public double Price { get; set; }
    }
}