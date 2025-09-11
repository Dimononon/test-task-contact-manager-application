using Microsoft.EntityFrameworkCore;
using test_task_contact_manager_application.Infrastructure;
using test_task_contact_manager_application.Models;

namespace test_task_contact_manager_application.Services
{
    public class ContactsService : IContactsService
    {
        private readonly ContactManagerDbContext _context;

        public ContactsService(ContactManagerDbContext context)
        {
            _context = context;
        }
        public async Task AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
        }
        public async Task AddContacts(IEnumerable<Contact> contact)
        {
            foreach (Contact item in contact)
            {
                _context.Contacts.Add(item);
            }
            await _context.SaveChangesAsync();
        }
        public async Task<Contact> GetContact(Guid id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
                throw new Exception("Contact can't be found");
            return contact;
        }
        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            var contacts = await _context.Contacts.ToListAsync();
            if (contacts == null)
                throw new Exception("Contacts can't be found");
            return contacts;
        }
        public async Task UpdateContact(Guid id, Contact newContact)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
                throw new Exception("Can't Found contact. Try create new contact.");

            _context.Entry(contact).CurrentValues.SetValues(newContact);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteContact(Guid id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
                throw new Exception("Contact can't be found");
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }
    }

}
