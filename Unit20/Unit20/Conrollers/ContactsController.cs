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
        public IActionResult Index()
        {
            ViewBag.Contacts = new ContactsContext().Contacts;
            return View();
        }

        // GET: Contacts/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // GET: Contacts/Delete
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        // Post: Contacts/Create
        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            using (var db = new ContactsContext())
            {
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

                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Contacts/Update
        [HttpGet()]
        public IActionResult Update(int id)
        {
            Console.WriteLine("Update!1");
            var ContactsData = new ContactsContext();

            var contact = ContactsData.Contacts.FirstOrDefault(e => e.ID == id);
         
            return View(contact);
        }

        // PUT: Contacts/Update
        [HttpPut]
        public IActionResult UpdateData(Contact contact)
        {
            using (var db = new ContactsContext())
            {
                var existingContact = db.Contacts.FirstOrDefault(c => c.ID == contact.ID);

                Console.WriteLine($"Update! {contact}");

                if (existingContact != null)
                {
                    existingContact.FirstName = contact.FirstName;
                    existingContact.LastName = contact.LastName;
                    existingContact.MiddleName = contact.MiddleName;
                    existingContact.PhoneNumber = contact.PhoneNumber;
                    existingContact.Address = contact.Address;
                    existingContact.Description = contact.Description;

                    db.SaveChanges();

                    return RedirectToAction("Details", new { id = existingContact.ID });
                }

                return RedirectToAction("Index");
            }
        }

        public IActionResult Details(int id)
        {
            var Contacts = new ContactsContext().Contacts;

            var contact = Contacts.FirstOrDefault(e => e.ID == id);

            return View(contact);
        }
    }
}

