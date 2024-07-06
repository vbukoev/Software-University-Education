using Contacts.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Data
{
    public class ContactsDbContext : IdentityDbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ApplicationUserContact> ApplicationUserContacts { get; set; }
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
            : base(options)
        {
             this.Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUserContact>()
                .HasKey(uc => new { uc.ApplicationUserId, uc.ContactId });

            base.OnModelCreating(builder);
        }
    }
}