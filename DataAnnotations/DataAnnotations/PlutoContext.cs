﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnnotations
{
    class PlutoContext : DbContext
    { 
        public PlutoContext()
            : base("name=PlutoContext")
        {

        }
        //DB Sets
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
    }
}
