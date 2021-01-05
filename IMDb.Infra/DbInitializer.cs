using IMDb.Domain.Entity;
using System.Linq;

namespace IMDb.Infra
{
    public static class DbInitializer
    {
        public static void Initialize(IMDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Status.Any())
            {
                return;   // DB has been seeded
            }                                   

            var status = new Status[]
            {
                new Status{StatusID = 1, Description = "Active"},
                new Status{StatusID = 2, Description = "Inactive"}
            };

            context.Status.AddRange(status);

            var genders = new Gender[]
            {
                new Gender{Description="Action"},
                new Gender{Description="Sci-fi"},
                new Gender{Description="Terror"}
            };

            context.Genders.AddRange(genders);

            var actors = new Actor[] 
            {
                new Actor{Name="Tom Hanks"},
                new Actor{Name="Will Smith"},
                new Actor{Name="Angelina Jolie"},
            };
            context.Actors.AddRange(actors);

            var directors = new Director[]
            {
                new Director{Name="Christopher Nolan"},
                new Director{Name="Martin Scorcese"},
            };
            context.Directors.AddRange(directors);


            context.SaveChanges();           
        }
    }
}
