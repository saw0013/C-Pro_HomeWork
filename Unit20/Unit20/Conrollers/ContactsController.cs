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
        public IActionResult Delete(int id)
        {
            var ContactsData = new ContactsContext();

            var contact = ContactsData.Contacts.FirstOrDefault(e => e.ID == id);

            return View(contact);
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

        //[HttpPut]
        //public IActionResult Update(int id)
        //{
        //    Console.WriteLine(id);

        //    return Ok();
        //}

        // PUT: Contacts/Update
        [HttpPut]
        public IActionResult Update (Contact id)
        {
            Console.WriteLine($"Update! {id}");

            using (var db = new ContactsContext())
            {
                var existingContact = db.Contacts.FirstOrDefault(c => c.ID == id.ID);

                if (existingContact != null)
                {
                    existingContact.FirstName = id.FirstName;
                    existingContact.LastName = id.LastName;
                    existingContact.MiddleName = id.MiddleName;
                    existingContact.PhoneNumber = id.PhoneNumber;
                    existingContact.Address = id.Address;
                    existingContact.Description = id.Description;

                    db.SaveChanges();
                }

                return Redirect("~/");
            }
        }

        [HttpDelete]
        public IActionResult Delete (Contact contact)
        {
            Console.WriteLine($"Delete");

            var ContactsData = new ContactsContext();

            if (contact == null)
            {
                return NotFound();
            }

            ContactsData.Contacts.Remove(contact);
            ContactsData.SaveChanges();

            return Ok();
        }

        public IActionResult Details(int id)
        {
            var Contacts = new ContactsContext().Contacts;

            var contact = Contacts.FirstOrDefault(e => e.ID == id);

            return View(contact);
        }
    }
}

