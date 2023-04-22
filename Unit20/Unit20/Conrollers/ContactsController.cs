using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Unit20
{
    public class ContactsController : Controller
    {
        // GET: Contacts/Index
        public IActionResult Index()
        {
            ViewBag.Contacts = new ContactsContext().Contacts; // Денамическая переменная 
            return View(); // Просто демонстрируем представлнеие
        }

        // GET: Contacts/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(); // Просто демонстрируем представлнеие
        }

        // GET: Contacts/Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var ContactsData = new ContactsContext();

            var contact = ContactsData.Contacts.FirstOrDefault(e => e.ID == id); // Находи контакт, который хотим удалить

            return View(contact); // Передаем контакт в представление
        }

        // Post: Contacts/Create
        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            using (var db = new ContactsContext())
            {
                // Добовляем введенные данные в базу даных
                db.Contacts.Add(
                    new Contact()
                    {
                        FirstName = contact.FirstName,
                        LastName = contact.LastName,
                        MiddleName = contact.MiddleName,
                        PhoneNumber = contact.PhoneNumber,
                        Address = contact.Address,
                        Description = contact.Description,
                    });

                db.SaveChanges(); // Сохраняем измененные данные
            }
            return RedirectToAction("Index"); // Переадресовываем в Index
        }

        // GET: Contacts/Update
        [HttpGet()]
        public IActionResult Update(int id)
        {
            var ContactsData = new ContactsContext();

            var contact = ContactsData.Contacts.FirstOrDefault(e => e.ID == id); // Находи контакт, который хотим обновить
         
            return View(contact); // Передаем контакт в представление
        }

        // PUT: Contacts/UpdateData
        [Route("Contacts/UpdateData/{id:int}")]
        [HttpPut("Contacts/UpdateData/{id:int}")]
        public IActionResult UpdateData(Contact model)
        {
            using (var db = new ContactsContext())
            {
                var existingContact = db.Contacts.FirstOrDefault(c => c.ID == model.ID);

                if (existingContact != null) //Если контакт найден, то изменяем данные
                {
                    existingContact.FirstName = model.FirstName;
                    existingContact.LastName = model.LastName;
                    existingContact.MiddleName = model.MiddleName;
                    existingContact.PhoneNumber = model.PhoneNumber;
                    existingContact.Address = model.Address;
                    existingContact.Description = model.Description;

                    db.Contacts.Update(existingContact); // Обновляем введеные данные
                    db.SaveChanges(); // Сохраняем измененные данные
                }
                 
                return Redirect("~/"); // Переадресовываем в конец
            }
        }

        // DELETE: Contacts/DeleteData
        [Route("Contacts/DeleteData/{id:int}")]
        [HttpDelete("Contacts/DeleteData/{id:int}")]
        public IActionResult DeleteData(Contact contact)
        {
            var ContactsData = new ContactsContext();

            if (contact == null) // Если не нашли кконтакт, выводим ошибкку
            {
                return NotFound();
            }

            ContactsData.Contacts.Remove(contact); // Удаляем данные
            ContactsData.SaveChanges(); // Сохраняем измененные данные

            return Redirect("~/"); // Переадресовываем в конец
        }

        // GET: Contacts/Details
        public IActionResult Details(int id)
        {
            var Contacts = new ContactsContext().Contacts;

            var contact = Contacts.FirstOrDefault(e => e.ID == id); // Находим контакт 

            return View(contact); // Показываем всю информацию в представление
        }
    }
}

