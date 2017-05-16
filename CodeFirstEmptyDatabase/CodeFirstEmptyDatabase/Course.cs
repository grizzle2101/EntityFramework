using System.Collections.Generic;

namespace CodeFirstEmptyDatabase
{
    public class Course //Course MUST have Author (One to Many)
    {
        public int Id { get; set;}
        public string Title { get; set; }
        public string Description { get; set; }
        public CourseLevel Level { get; set; }
        public float FullPrice { get; set; }
        public Author Author { get; set; } //Navigation Property
        public IList<Tag> Tags { get; set; }
    }
}
