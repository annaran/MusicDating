
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicDating.Models.Entities;

namespace MusicDating.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
   
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }


           protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Only needed when inheriting from IdentityDbContext.
            // Call base functionality from the OnModelCreating method in the IdentityDbContext class.
            
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser {  Id="1", DateCreated = new System.DateTime(2020, 12, 24), FirstName = "Daniel", LastName = "Smith", UserName = "daniel@daniel.dk", Email="daniel@daniel.dk" },
                new ApplicationUser {  Id="2", DateCreated = new System.DateTime(2020, 10, 22), FirstName = "Simone", LastName = "White", UserName = "simone@simone.dk", Email="simone@simone.dk"  }
            );


                modelBuilder.Entity<PracticeFrequency>().HasData(
                new PracticeFrequency { PracticeFrequencyId = 1, Description = "Many times a week"},
                new PracticeFrequency { PracticeFrequencyId = 2, Description = "1 time a week" },
                new PracticeFrequency { PracticeFrequencyId = 3, Description = "1 time every other week"},
                new PracticeFrequency { PracticeFrequencyId = 4, Description = "1 time a month" },
                new PracticeFrequency { PracticeFrequencyId = 5, Description = "1 time every other month or less" }

            );

                modelBuilder.Entity<Size>().HasData(
                new Size { SizeId = 1, Description = "1 - 4 musicians"},
                new Size { SizeId = 2, Description = "5 - 9 musicians" },
                new Size { SizeId = 3, Description = "10 - 24 musicians"},
                new Size { SizeId = 4, Description = "25 - 49 musicians" },
                new Size { SizeId = 5, Description = "50 or more musicians" }

            );



// add data instruments and userInstruemnts

            modelBuilder.Entity<Instrument>().HasData(
              
                new Instrument { InstrumentId = 1, Name = "Piano" },
                new Instrument { InstrumentId = 2, Name = "Violin" },
                new Instrument { InstrumentId = 3, Name = "Trumpet" },
                new Instrument { InstrumentId = 4, Name = "Saxophone" },
                new Instrument { InstrumentId = 5, Name = "Cello" },
                new Instrument { InstrumentId = 6, Name = "Accordion" },
                new Instrument { InstrumentId = 7, Name = "Flute" },
                new Instrument { InstrumentId = 8, Name = "Drums" },
                new Instrument { InstrumentId = 9, Name = "Guitar" }
            );

                modelBuilder.Entity<UserInstrument>().HasData(
                new UserInstrument { ApplicationUserId = "1", InstrumentId = 7, Level = 1 },
                new UserInstrument { ApplicationUserId = "1", InstrumentId = 8, Level = 3 },
                new UserInstrument { ApplicationUserId = "1", InstrumentId = 9, Level = 3 },
                new UserInstrument { ApplicationUserId = "2", InstrumentId = 8, Level = 3 },
                new UserInstrument { ApplicationUserId = "2", InstrumentId = 9, Level = 1 }

            );

                modelBuilder.Entity<UserInstrumentGenre>().HasData(
                new UserInstrumentGenre { UserInstrumentGenreId = 1, InstrumentId = 7, GenreId = 1, ApplicationUserId = "1" },
                new UserInstrumentGenre { UserInstrumentGenreId = 2, InstrumentId = 7, GenreId = 3, ApplicationUserId = "1"},
                new UserInstrumentGenre { UserInstrumentGenreId = 3, InstrumentId = 8, GenreId = 3, ApplicationUserId = "1"},
                new UserInstrumentGenre { UserInstrumentGenreId = 4, InstrumentId = 9, GenreId = 2, ApplicationUserId = "1" },
                new UserInstrumentGenre { UserInstrumentGenreId = 5, InstrumentId = 8, GenreId = 2, ApplicationUserId = "2" },
                new UserInstrumentGenre { UserInstrumentGenreId = 6, InstrumentId = 9, GenreId = 7, ApplicationUserId = "2" },
                new UserInstrumentGenre { UserInstrumentGenreId = 7, InstrumentId = 9, GenreId = 1, ApplicationUserId = "2" },
                new UserInstrumentGenre { UserInstrumentGenreId = 8, InstrumentId = 9, GenreId = 4, ApplicationUserId = "2" },
                new UserInstrumentGenre { UserInstrumentGenreId = 9, InstrumentId = 9, GenreId = 6, ApplicationUserId = "2" }

            );



            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = 1, Name = "Classical" },
                new Genre { GenreId = 2, Name = "Rock" },
                new Genre { GenreId = 3, Name = "Blues" },
                new Genre { GenreId = 4, Name = "Country" },
                new Genre { GenreId = 5, Name = "Pop" },
                new Genre { GenreId = 6, Name = "Jazz" },
                new Genre { GenreId = 7, Name = "Metal" },
                new Genre { GenreId = 8, Name = "Folk" },
                new Genre { GenreId = 9, Name = "HipHop" },
                new Genre { GenreId = 10, Name = "PunkRock" }
            );


            modelBuilder.Entity<Ensemble>().HasData(
                new Ensemble { EnsembleId = 1, SizeId = 1, PracticeFrequencyId = 1, Name = "Spice Girls", City = "Kobenhavn", Postcode = "2200", Description = "Cool band" },
                new Ensemble { EnsembleId = 2, SizeId = 1, PracticeFrequencyId = 1, Name = "U2", City = "Kobenhavn", Postcode = "2200", Description = "Cool band" },
                new Ensemble { EnsembleId = 3, SizeId = 1, PracticeFrequencyId = 1, Name = "3 doors down", City = "Kobenhavn", Postcode = "2200", Description = "Cool band" }
            );

            modelBuilder.Entity<EnsembleGenre>().HasData(
                new EnsembleGenre { EnsembleId = 1, GenreId = 1 },
                new EnsembleGenre { EnsembleId = 1, GenreId = 2 },
                new EnsembleGenre { EnsembleId = 2, GenreId = 1 }
            );










            modelBuilder.Entity<EnsembleGenre>()
                .HasKey(bc => new { bc.GenreId, bc.EnsembleId });  
            modelBuilder.Entity<EnsembleGenre>()
                .HasOne(bc => bc.Ensemble)
                .WithMany(b => b.EnsembleGenres)
                .HasForeignKey(bc => bc.EnsembleId);  
            modelBuilder.Entity<EnsembleGenre>()
                .HasOne(bc => bc.Genre)
                .WithMany(c => c.EnsembleGenres)
                .HasForeignKey(bc => bc.GenreId);

// userinstrumentgenre
            modelBuilder.Entity<UserInstrumentGenre>()
                .HasKey(bc => bc.UserInstrumentGenreId);  
            modelBuilder.Entity<UserInstrumentGenre>()
                .HasOne(bc => bc.UserInstrument)
                .WithMany(b => b.UserInstrumentGenres)
                .HasForeignKey(bc => new { bc.ApplicationUserId, bc.InstrumentId });  
            modelBuilder.Entity<UserInstrumentGenre>()
                .HasOne(bc => bc.Genre)
                .WithMany(c => c.UserInstrumentGenres)
                .HasForeignKey(bc => bc.GenreId);

 






            modelBuilder.Entity<PostGenre>()
                .HasKey(pg => new { pg.PostId, pg.GenreId });  
            modelBuilder.Entity<PostGenre>()
                .HasOne(pg => pg.Post)
                .WithMany(p => p.PostGenres)
                .HasForeignKey(pg => pg.PostId);  
            modelBuilder.Entity<PostGenre>()
                .HasOne(pg => pg.Genre)
                .WithMany(g => g.PostGenres)
                .HasForeignKey(pg => pg.GenreId);


            modelBuilder.Entity<UserInstrument>()
                .HasKey(bc => new { bc.ApplicationUserId, bc.InstrumentId });  
            modelBuilder.Entity<UserInstrument>()
                .HasOne(bc => bc.ApplicationUser)
                .WithMany(b => b.UserInstruments)
                .HasForeignKey(bc => bc.ApplicationUserId);  
            modelBuilder.Entity<UserInstrument>()
                .HasOne(bc => bc.Instrument)
                .WithMany(c => c.UserInstruments)
                .HasForeignKey(bc => bc.InstrumentId);












        }


        // This means that EF (Entity Framework) will create a table called Instrument based
        // on our Instrument class.
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Post> Posts { get; set; }

        // This means that EF (Entity Framework) will create a table called Instrument based
        // on our Instrument class.
        public DbSet<MusicDating.Models.Entities.Agent> Agent { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<MusicDating.Models.Entities.Ensemble> Ensembles { get; set; }
        public DbSet<MusicDating.Models.Entities.Genre> Genres { get; set; }
       // public DbSet<EnsembleGenre> EnsembleGenres { get; set; }
        public DbSet<UserInstrument> UserInstruments { get; set; }
        public DbSet<PostGenre> PostGenres { get; set; }
        public DbSet<UserInstrumentGenre> UserInstrumentGenres { get; set; }
        public DbSet<PracticeFrequency> PracticeFrequencies { get; set; }
        public DbSet<Size> Sizes { get; set; }
       
    }
}
