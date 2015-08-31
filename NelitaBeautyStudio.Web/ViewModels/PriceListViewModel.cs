namespace NelitaBeautyStudio.Web.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using NelitaBeautyStudio.Common;
    using NelitaBeautyStudio.Models;

    public class PriceListViewModel
    {
        [Display(Name = "Име")]
        [Required(ErrorMessage = "Полето {0} е задължително!")]
        [StringLength(
            GlobalConstants.TextFieldLengthMax,
            ErrorMessage = "Полето {0} трябва да бъде между {2} и {1} символа!",
            MinimumLength = GlobalConstants.TextFieldLengthMin)]
        public string Title { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}