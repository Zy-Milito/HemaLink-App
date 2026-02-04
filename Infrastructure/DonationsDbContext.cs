using Domain.Models;
using Domain.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DonationsDbContext : DbContext
    {
        public DonationsDbContext(DbContextOptions<DonationsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Donator admin = new Donator()
            {
                Id = 1,
                Name = "admin",
                Email = "admin",
                Password = BCrypt.Net.BCrypt.HashPassword("admin"),
                Role = Role.Admin
            };

            Requester GruppeSechs = new Requester()
            {
                Id = 2,
                Name = "Gruppe Sechs",
                Email = "gruppesechs@mail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("gruppesechs"),
                Role = Role.Standard,
                AdmissionStatus = AdmissionStatus.Accepted
            };

            Requester Gamma = new Requester()
            {
                Id = 3,
                Name = "Grupo Gamma",
                Email = "grupogamma@mail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("gamma"),
                Role = Role.Standard,
                AdmissionStatus = AdmissionStatus.Pending
            };

            Donator Gabriel = new Donator()
            {
                Id = 4,
                Name = "Gabriel",
                Email = "gabriel@mail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("gabriel"),
                Role = Role.Standard
            };

            modelBuilder.Entity<Donator>().HasData(admin, Gabriel);
            modelBuilder.Entity<Requester>().HasData(GruppeSechs, Gamma);

            modelBuilder.Entity<Requester>(entity =>
            {
                entity.Property(e => e.AdmissionStatus)
                      .IsRequired();
            });

            modelBuilder.Entity<User>()
                .HasDiscriminator<string>("UserType")
                .HasValue<Donator>("Donator")
                .HasValue<Requester>("Requester");


            base.OnModelCreating(modelBuilder);
        }
    }
}