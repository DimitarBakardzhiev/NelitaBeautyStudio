namespace NelitaBeautyStudio.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PriceList
    {
        public PriceList()
        {
            this.Services = new HashSet<Service>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
}
