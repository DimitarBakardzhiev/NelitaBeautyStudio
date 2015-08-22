namespace NelitaBeautyStudio.Web.ViewModels
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using NelitaBeautyStudio.Common;
    using NelitaBeautyStudio.Models;
    using NelitaBeautyStudio.Web.Infrastructure.Mapping;

    public class ContactViewModel : IMapFrom<Contact>
    {
        [Display(Name = "Тип контакт")]
        [Required(ErrorMessage = "Полето {0} е задължително!")]
        [StringLength(
            GlobalConstants.TextFieldLengthMax,
            ErrorMessage = "Полето {0} трябва да бъде между {2} и {1} символа!", 
            MinimumLength = GlobalConstants.TextFieldLengthMin)]
        public string Type { get; set; }

        [Display(Name = "Стойност на контакт")]
        [Required(ErrorMessage = "Полето {0} е задължително!")]
        [StringLength(
            GlobalConstants.TextFieldLengthMax, 
            ErrorMessage = "Полето {0} трябва да бъде между {2} и {1} символа!",
            MinimumLength = GlobalConstants.TextFieldLengthMin)]
        public string Value { get; set; }

        [Display(Name = "Приоритет")]
        [DefaultValue(Priority.Normal)]
        public Priority Priority { get; set; }
    }
}