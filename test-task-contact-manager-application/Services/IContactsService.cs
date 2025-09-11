using test_task_contact_manager_application.Models;

namespace test_task_contact_manager_application.Services
{
    public interface IContactsService
    {
        Task AddContact(Contact contact);
        Task AddContacts(IEnumerable<Contact> contact);
        Task DeleteContact(Guid id);
        Task<IEnumerable<Contact>> GetAllContacts();
        Task<Contact> GetContact(Guid id);
        Task UpdateContact(Guid id, Contact newContact);
    }
}