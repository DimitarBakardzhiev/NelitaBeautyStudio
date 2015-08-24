namespace NelitaBeautyStudio.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Price { get; set; }

        public int PriceListId { get; set; }

        public virtual PriceList PriceList { get; set; }
    }
}
