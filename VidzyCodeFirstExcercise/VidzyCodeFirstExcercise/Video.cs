using System;
using System.Collections.Generic;

namespace VidzyCodeFirstExcercise
{
    public class Video
    {
        public int Id { get; set;}
        public string Name { get; set; }
        public DateTime? ReleasedDate { get; set; }
        public IList<Genre> Genres { get; set; } //Video Can have many Genres
    }
}