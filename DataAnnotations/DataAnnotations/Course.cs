using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAnnotations
{
    public class Course
    {
        public Course()
        {
            Tags = new HashSet<Tag>();
        }
        public int Id { get; set; }

        //Change 1 - Required & Length Changes to Name & Description.
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
        public int Level { get; set; }
        public float FullPrice { get; set; }
        
        /*Change 2 - Overriding the Autor_Id FK Value in the DB
        *Create Property with the Name we prefer to use Eg Author
        *Link Property to Navigation Property.
        * 
        * The Problem with this "Magic String", is we change the name of the property,
        * intellisense will not know to change this string for us and it will blow up.
        * Fluent API uses Lambda Expressions, so if we change the names we won't face this issue.
        */

        [ForeignKey("Author")] //Link to Author Navigation Property
        public int AuthorId { get; set; } //New Property with Name WE want.

        public virtual Author Author { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
