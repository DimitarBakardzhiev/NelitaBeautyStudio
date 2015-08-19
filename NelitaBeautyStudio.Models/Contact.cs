namespace NelitaBeautyStudio.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public Priority Priority { get; set; }
    }
}
