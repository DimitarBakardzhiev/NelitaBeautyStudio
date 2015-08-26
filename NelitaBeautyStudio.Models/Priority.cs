namespace NelitaBeautyStudio.Models
{
    using System.ComponentModel.DataAnnotations;

    public enum Priority
    {
        [Display(Name = "Нисък")]
        Low = 0,

        [Display(Name = "Нормален")]
        Normal = 1,

        [Display(Name = "Висок")]
        High = 2
    }
}