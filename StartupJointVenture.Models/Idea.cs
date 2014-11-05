using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StartupJointVenture.Models
{
    public class Idea
    {
        private ICollection<Like> likes;
        private ICollection<Comment> comments;

        public Idea()
        {
            this.likes = new HashSet<Like>();
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int CategoryID { get; set; }

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
    }
}
