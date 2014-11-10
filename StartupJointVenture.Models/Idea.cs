namespace StartupJointVenture.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Idea
    {
        private ICollection<Like> likes;
        private ICollection<Comment> comments;
        private ICollection<Cofounder> cofounders;

        public Idea()
        {
            this.likes = new HashSet<Like>();
            this.cofounders = new HashSet<Cofounder>();
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Title { get; set; }

        [MaxLength(1200)]
        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Like> Likes
        {
            get { return this.likes; }
            set { this.likes = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Cofounder> Cofounders
        {
            get { return this.cofounders; }
            set { this.cofounders = value; }
        }
    }
}
