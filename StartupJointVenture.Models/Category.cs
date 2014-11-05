using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupJointVenture.Models
{
    public class Category
    {
        private ICollection<Idea> ideas;

        public Category()
        {
            this.ideas = new HashSet<Idea>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Idea> Ideas
        {
            get { return this.ideas; }
            set { this.ideas = value; }
        }
        
    }
}
