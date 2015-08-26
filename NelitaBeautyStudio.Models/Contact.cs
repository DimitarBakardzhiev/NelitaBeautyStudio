namespace NelitaBeautyStudio.Models
{
    using System.ComponentModel;
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
        [DefaultValue(Priority.Normal)]
        public Priority Priority { get; set; }
    }
}
