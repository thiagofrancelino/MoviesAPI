using System.Collections.Generic;

namespace IMDb.Domain.Entity
{
    public class Actor
    {
        public int ActorID { get; set; }
        public string Name { get; set; }


        public ICollection<MoviesActors> MoviesActors { get; set; }
    }
}
