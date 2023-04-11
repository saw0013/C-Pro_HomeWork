using Microsoft.AspNetCore.Mvc;

namespace Unit19.Contolers
{
    public class ContactsController : Controller
    {
        private readonly List<Contact> contacts;

        public ContactsController()
        {
            contacts = new List<Contact>
        {
            new Contact { ID = 1, LastName = "Иванов", FirstName = "Иван", MiddleName = "Иванович", PhoneNumber = "+7 (123) 456-7890", Address = "Москва, ул. Пушкина, д. 1", Description = "Старший менеджер" },
            new Contact { ID = 2, LastName = "Петров", FirstName = "Петр", MiddleName = "Петрович", PhoneNumber = "+7 (123) 456-7891", Address = "Москва, ул. Лермонтова, д. 2", Description = "Младший менеджер" },
            new Contact { ID = 3, LastName = "Сидоров", FirstName = "Сидор", MiddleName = "Сидорович", PhoneNumber = "+7 (123) 456-7892", Address = "Москва, ул. Гоголя, д. 3", Description = "Консультант" },
        };
        }

        public IActionResult Index()
        {
            return View(contacts);
        }

        public IActionResult Details(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ID == id);
            return View(contact);
        }
    }
}
