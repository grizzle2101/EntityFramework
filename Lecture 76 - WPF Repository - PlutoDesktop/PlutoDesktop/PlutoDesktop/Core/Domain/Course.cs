using System.Collections.ObjectModel;

namespace PlutoDesktop.Core.Domain
{
    public class Course
    {
        public Course()
        {
            //Change 2 - from Hashset to ObserveableCollection
            Tags = new ObservableCollection<Tag>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Level { get; set; }

        public float FullPrice { get; set; }

        public virtual Author Author { get; set; }

        public int AuthorId { get; set; }

        //Change 1 - From ICollection to ObserveableCollection
        public virtual ObservableCollection<Tag> Tags { get; set; }

        public Cover Cover { get; set; }
    }
}
