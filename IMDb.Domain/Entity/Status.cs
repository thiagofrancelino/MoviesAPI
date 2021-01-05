using System.ComponentModel.DataAnnotations.Schema;

namespace IMDb.Domain.Entity
{
    public class Status
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StatusID { get; set; }
        public string Description { get; set; }
    }
}
