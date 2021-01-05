using System;
using System.Collections.Generic;

namespace IMDb.Domain.Entity
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }        
        public bool IsAdmin { get; set; }
        public DateTime RecordDate { get; set; }
        
        public int StatusID { get; set; }
        public Status Status { get; set; }
        public ICollection<MovieRate> MovieRates { get; set; }
    }
}
