using Microsoft.EntityFrameworkCore;
using TicketApi.Entities;

namespace TicketApi.DbContexts
{
    public class TicketContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        public TicketContext(DbContextOptions<TicketContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    Username = "aleksandrajovevska",
                    Password = "jovevskaaleksandra",
                    Role = TicketApi.Model.Role.Admin
                },
                new User()
                {
                    Id = 2,
                    Username = "petarjovevski",
                    Password = "jovevskipetar",
                    Role = TicketApi.Model.Role.User
                });
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket()
                {
                    Id = 3,
                    Title = "The Godfather 1",
                    Description = "It focuses on the transformation of his youngest son, " +
                    "Michael Corleone (Pacino), from reluctant family outsider to ruthless mafia boss",
                    Price = "10"
                },
                new Ticket()
                {
                    Id = 4,
                    Title = "The Godfather 2",
                    Description = "Part II develops this theme further, showing us how the Corleone family " +
                    "operates within a political framework.",
                    Price = "10"
                });
            base.OnModelCreating(modelBuilder);
        }

     }
}
