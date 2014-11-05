using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StartupJointVenture.Models
{
    public class Like
    {
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int IdeaId { get; set; }

        public virtual Idea Idea { get; set; }
    }
}
