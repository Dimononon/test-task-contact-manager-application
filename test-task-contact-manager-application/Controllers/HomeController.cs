using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;
using test_task_contact_manager_application.Models;
using test_task_contact_manager_application.Services;

namespace test_task_contact_manager_application.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactsService _contactsService;

        public HomeController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }

        public async Task<IActionResult> Index()
        {
            var contacts = await _contactsService.GetAllContacts();
            return View(contacts);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, [FromBody] Contact model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            try
            {
                await _contactsService.UpdateContact(id, model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _contactsService.DeleteContact(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file selected");

            int importedCount = 0;
            using (var stream = file.OpenReadStream())
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    var fields = line.Split(',');
                    if (fields.Length != 5) continue;

                    var contact = new Contact
                    {
                        Name = fields[0],
                        DateOfBirth = DateOnly.TryParse(fields[1], out var dob) ? dob : DateOnly.MinValue,
                        Married = bool.TryParse(fields[2], out var married) && married,
                        Phone = fields[3],
                        Salary = decimal.TryParse(fields[4], CultureInfo.InvariantCulture, out var salary ) ? salary : 0
                    };
                    await _contactsService.AddContact(contact);
                    importedCount++;
                }
            }

            return Ok(new { success = true, imported = importedCount });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
