using Learn_and_Play___Architecture___DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Learn_and_Play___Architecture___DAL
{
    public class AddressesContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public string DbPath { get; }

        public AddressesContext(string connectionString = "Data Source=.;Initial Catalog=Addresses;Integrated Security=SSPI;MultipleActiveResultSets=True")
        {
            DbPath = connectionString;
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(DbPath);
    }
}