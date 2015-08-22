namespace NelitaBeautyStudio.Models
{
    using System.ComponentModel.DataAnnotations;

    public enum Priority
    {
        [Display(Name = "Нисък")]
        Low = 1,

        // The value is set to zero to appear as a default value in dropdownlists
        [Display(Name = "Нормален")]
        Normal = 0,

        [Display(Name = "Висок")]
        High = 2
    }
}