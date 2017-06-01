using System.Collections.Generic;

namespace Queries
{
    public class Course
    {
        public Course()
        {
            Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Level { get; set; }

        public float FullPrice { get; set; }

        public virtual Author Author { get; set; }

        public int AuthorId { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public Cover Cover { get; set; }

        //Lecture 51 - Deferred Execution - Task 2
        //Sometimes we had Calculated Columns like so to make it more expressive.
        //This is a Calculate Column
        public bool IsBeginnerCourse
        {
            get { return Level == 1; }
        }
    }
}
