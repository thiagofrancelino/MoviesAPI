using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDb.Domain.Entity
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Name { get; set; }
        public DateTime RecordDate { get; set; }

        public int GenderID { get; set; }
        public Gender Gender{ get; set; }       
        public int StatusID { get; set; }
        public Status Status { get; set; }
        public int DirectorID { get; set; }
        public Director Director { get; set; }

        [NotMapped]
        public int[] ActorsIDs { get; set; }

        public ICollection<MoviesActors> MoviesActors { get ; set; }
        
    }
}
