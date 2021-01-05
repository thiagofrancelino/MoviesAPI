using System;

namespace IMDb.Domain.Entity
{
    public class MovieRate
    {
        public int MovieRateID { get; set; }
        public int Rate { get; set; }

        public int MovieID { get; set; }
        public Movie Movie { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public DateTime RecordDate { get; set; }
    }
}
