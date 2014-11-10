namespace StartupJointVenture.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Cofounder
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int IdeaId { get; set; }

        public virtual Idea Idea { get; set; }

        [Required]
        [MaxLength(100)]
        public string Location { get; set; }

        [Required]
        [MaxLength(300)]
        [DisplayName("Professional skills")]
        public string ProfSkills { get; set; }

        [Required]
        public DateTime DateJoined { get; set; }
    }
}
