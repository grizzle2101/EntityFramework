namespace OverridingCodeFirstConventions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Courses")]
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        //Lecutre 1 -Ovveriding Convention, Description is now REQUIRED eg NOT Null.
        //[Required]
        //Overriden for Part 2 of Lecture 1 - Using Fluent API instead.
        public string Description { get; set; }

        public int Level { get; set; }

        public float FullPrice { get; set; }

        public int? Author_Id { get; set; }

        public virtual Author Author { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
