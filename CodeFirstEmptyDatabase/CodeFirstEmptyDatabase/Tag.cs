using System.Collections.Generic;

namespace CodeFirstEmptyDatabase
{
    public class Tag //Many to Many Relationship with Tag & Courses
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Course> Courses { get; set; }
    }
}
