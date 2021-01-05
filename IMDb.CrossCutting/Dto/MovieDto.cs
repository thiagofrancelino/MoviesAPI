namespace IMDb.CrossCutting.Dto
{
    public class MovieDto
    {
        public int MovieID { get; set; }
        public string Name { get; set; }        
        public int GenderID { get; set; }       
        public int DirectorID { get; set; }
        
        public int[] Actors { get; set; }
    }
}
