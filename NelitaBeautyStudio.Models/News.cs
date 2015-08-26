namespace NelitaBeautyStudio.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class News
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
    }
}
