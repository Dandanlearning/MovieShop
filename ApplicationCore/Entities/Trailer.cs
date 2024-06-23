using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Trailer
    {
        public int Id { get; set; }
        public string TrailerUrl { get; set; }
        public string Name { get; set; }

        // reference to movie Id as Foreign Key FK
        public int MovieId { get; set; }

        // Navigation property: is nothing but property 
        // that helps you to build relationship with other entity
        // related information for foreign key
        // it is telling that the movieId above is from Movie entity
        public Movie Movie { get; set; }
    }
}
