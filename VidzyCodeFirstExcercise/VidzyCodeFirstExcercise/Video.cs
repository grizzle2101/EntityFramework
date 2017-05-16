using System;
using System.Collections.Generic;

namespace VidzyCodeFirstExcercise
{
    public class Video
    {
        public int Id { get; set;}
        public string Name { get; set; }
        public DateTime? ReleasedDate { get; set; }
        //Iteration 1 - Video Can have many Genres
        //public IList<Genre> Genres { get; set; }

        //Iteration 2 - Video Can have only ONE Genre
        public Genre Genre { get; set; }
        
        //Iteration 3 - Adding Enum to Video
        public Classification Classification { get; set; }
    }
}