using System;
using System.IO;
using System.Security.Cryptography.Xml;
using DataAccess.Entity;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.AzureAppServices.Internal;
using Microsoft.IdentityModel.Protocols;

namespace DataAccess
{
    public class PuffContext : DbContext
    {
        protected HostingApplication.Context context;

        public DbContextOptions ContextOptions;
        
        public PuffContext()
        {
        }

        public PuffContext(DbContextOptions<PuffContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;userid=root;database=puffy;Convert Zero Datetime=True");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Many to many

            // create many to many relationship

            // Event-User Participants
            modelBuilder.Entity<EventParticipants>().HasKey(ep => new {ep.EventId, ep.UserId});

            modelBuilder.Entity<EventParticipants>()
                .HasOne(ep => ep.Event)
                .WithMany(e => e.Participants)
                .HasForeignKey(ep => ep.EventId);

            modelBuilder.Entity<EventParticipants>()
                .HasOne(ep => ep.User)
                .WithMany(u => u.ParticpationEvents)
                .HasForeignKey(ep => ep.UserId);

            // Event-User Hosts 
            modelBuilder.Entity<EventHosts>()
                .HasKey(eh => new {eh.EventId, eh.UserId});

            modelBuilder.Entity<EventHosts>()
                .HasOne(eh => eh.Event)
                .WithMany(e => e.Hosts)
                .HasForeignKey(eh => eh.EventId);

            modelBuilder.Entity<EventHosts>()
                .HasOne(eh => eh.User)
                .WithMany(u => u.HostEvents)
                .HasForeignKey(eh => eh.UserId);

            // Movie-Category
            modelBuilder.Entity<MovieCategory>()
                .HasKey(mc => new {mc.CategoryId, mc.MovieId});

            modelBuilder.Entity<MovieCategory>()
                .HasOne(mc => mc.Category)
                .WithMany(c => c.Movies)
                .HasForeignKey(mc => mc.CategoryId);

            modelBuilder.Entity<MovieCategory>()
                .HasOne(mc => mc.Movie)
                .WithMany(m => m.Categories)
                .HasForeignKey(mc => mc.MovieId);

            // Seance-Event
            modelBuilder.Entity<SeanceEvent>()
                .HasKey(se => new {se.EventId, se.SeanceId});

            modelBuilder.Entity<SeanceEvent>()
                .HasOne(se => se.Event)
                .WithMany(e => e.Seances)
                .HasForeignKey(se => se.EventId);

            modelBuilder.Entity<SeanceEvent>()
                .HasOne(se => se.Seance)
                .WithMany(s => s.Events)
                .HasForeignKey(se => se.SeanceId);



            #endregion

            #region one to many

            // Create one to many relationships
            // Event => Creator
            modelBuilder.Entity<Event>()
                .HasOne(e => e.Creator)
                .WithMany(u => u.CreatedEvents);

            // Vote
//            modelBuilder.Entity<Event>()
//                .HasMany(e => e.Votes)
//                .WithOne(v => v.Event)
//                .OnDelete(DeleteBehavior.Cascade);
//
//            modelBuilder.Entity<Seance>()
//                .HasMany(s => s.Votes)
//                .WithOne(v => v.Seance)
//                .OnDelete(DeleteBehavior.Cascade);
//
//            modelBuilder.Entity<User>()
//                .HasMany(u => u.Votes)
//                .WithOne(v => v.User)
//                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Event)
                .WithMany(e => e.Votes);

            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Seance)
                .WithMany(s => s.Votes);

            modelBuilder.Entity<Vote>()
                .HasOne(v => v.User)
                .WithMany(u => u.Votes);

            // Seance
            modelBuilder.Entity<Seance>()
                .HasOne(s => s.Cinema)
                .WithMany(s => s.Seances);

            modelBuilder.Entity<Seance>()
                .HasOne(s => s.Movie)
                .WithMany(m => m.Seances);

            #endregion

            #region one to one

            // Create one to one relationships
            modelBuilder.Entity<User>()
                .HasOne(u => u.InfoUser)
                .WithOne(u => u.User)
                .HasForeignKey<InfoUser>(i => i.UserId);

            #endregion
        }

        #region DbSet

        public DbSet<User> Users { get; set; }

        public DbSet<InfoUser> InfoUsers { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Vote> Votes { get; set; }

        public DbSet<Seance> Seances { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Cinema> Cinemas { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Adress> Adresses { get; set; }
        
        #endregion

    }
}