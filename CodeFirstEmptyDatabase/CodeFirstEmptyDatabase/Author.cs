using System.Collections.Generic;

namespace CodeFirstEmptyDatabase
{
    public class Author //Author can have MANY courses. 
    {
        public int Id { get; set;}
        public string Name { get; set; }
        public IList<Course> Courses { get; set; }
    }
}
