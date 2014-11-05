using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StartupJointVenture.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int IdeaId { get; set; }

        public virtual Idea Idea { get; set; }
    }
}
