namespace NelitaBeautyStudio.Web.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using NelitaBeautyStudio.Common;

    public class NewsViewModel
    {
        [Display(Name = "Заглавие")]
        [Required(ErrorMessage = "Полето {0} е задължително!")]
        [StringLength(
            GlobalConstants.TextFieldLengthMax,
            ErrorMessage = "Полето {0} трябва да бъде между {2} и {1} символа!",
            MinimumLength = GlobalConstants.TextFieldLengthMin)]
        public string Title { get; set; }

        [Display(Name = "Съдържание")]
        [Required(ErrorMessage = "Полето {0} е задължително!")]
        [AllowHtml]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
    }
}