using System.Collections.Generic;

namespace Queries
{
    public class Tag
    {
        public Tag()
        {
            Courses = new HashSet<Course>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public Moderator Moderator { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }

    public class Moderator
    {
        public string ModeratorName { get; set; }
    }
}
