using ContactsAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace ContactsAPI.DB
{
    public class ContactsContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Phone> Phone { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = ContactsDatabase"
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
            .HasOne(b => b.Address);
            modelBuilder.Entity<Contact>()
            .Navigation(b => b.Address)
            .UsePropertyAccessMode(PropertyAccessMode.Property);

            modelBuilder.Entity<Contact>()
            .HasMany(b => b.Phone)
            .WithOne();
            modelBuilder.Entity<Contact>()
            .Navigation(b => b.Phone)
            .UsePropertyAccessMode(PropertyAccessMode.Property);
            
            /*
             * TODO add a default row, as currently the UI requires an existing row to add a new contact
            #region ContactSeed
            var address = new Address() { Id = 1,  Line1 = "23 Wilmot Street", Line2 = "Manchester" };
            var phone = new List<Phone>()
            {
            { new  { ContactId = 1, Id = 1, Type = Enums.PhoneType.Home, Prefix = "+44", Number = "01215896547" } },
            { new Phone() { ContactId = 1, Id = 2, Type = Enums.PhoneType.Mobile, Prefix = "+44", Number = "07254236587" } },
            { new Phone() { ContactId = 1, Id = 3, Type = Enums.PhoneType.Work, Prefix = "+44", Number = "016458547895" }
            }};

            modelBuilder.Entity<Contact>().HasData(new { AddressId = 1, Id = 1, FirstName = "Fred", LastName = "Jones", Address = address });
            #endregion
            */
        }

    }
}
