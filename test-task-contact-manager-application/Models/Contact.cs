
namespace test_task_contact_manager_application.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateOnly Date { get; set; }
        public bool Married { get; set; }
        public string? Phone { get; set; }
        public decimal Slary { get; set; }
    }
}

