
using Microsoft.EntityFrameworkCore;
using test_task_contact_manager_application.Models;

namespace test_task_contact_manager_application.Infrastructure
{
    public class ContactManagerDbContext :DbContext
    {
        public ContactManagerDbContext(DbContextOptions<ContactManagerDbContext> options) : base(options) { }
        public DbSet<Contact> Contacts => Set<Contact>();
    }
}
