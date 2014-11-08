namespace StartupJointVenture.Web.ViewModels
{
    using StartupJointVenture.Models;
    using System.ComponentModel.DataAnnotations;

    public class IdeaViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Title field must be between {1} and {2} symbols")]
        public string Title { get; set; }

        [Required]
        [StringLength(1200, MinimumLength = 10, ErrorMessage = "Content field must be between {1} and {2} symbols")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

    }
}