using System.Security.Claims;
using Contacts.Data;
using Contacts.Data.Entities;
using Contacts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        private readonly ContactsDbContext _context;

        public ContactsController(ContactsDbContext context)
        {
            _context = context;
        }

        public IActionResult All()
        {
            AllContactModel allContacts = new AllContactModel{};

            allContacts.Contacts = _context.Contacts.Select(c => new ContactViewModel
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                Address = c.Address,
                Website = c.Website
            });

            return View(allContacts);
        }

        public IActionResult Add()
        {
            ContactFormModel contactModel = new();

            return View(contactModel);
        }

        [HttpPost]
        public IActionResult Add(ContactFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var contact = new Contact
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                Website = model.Website
            };

            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return RedirectToAction("All", "Contacts");
        }

        private string GetUserId()
            => this.User.FindFirstValue(ClaimTypes.NameIdentifier);

        public IActionResult Edit(int id)
        {
            var contact= _context.Contacts.Find(id);

            if (contact == null)
            {
                return BadRequest();
            }

            ContactFormModel model = new ContactFormModel()
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Address = contact.Address,
                PhoneNumber = contact.PhoneNumber,
                Email = contact.Email,
                Website = contact.Website

            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, ContactFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var contact = _context.Contacts.Find(id);

            if (contact == null)
            {
                return BadRequest();
            }

            contact.FirstName = model.FirstName;
            contact.LastName = model.LastName;
            contact.Email = model.Email;
            contact.PhoneNumber = model.PhoneNumber;
            contact.Address = model.Address;
            contact.Website = model.Website;

            _context.SaveChanges();

            return RedirectToAction("All", "Contacts");
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddToTeam(int id)
        {
            var contact = _context.Contacts.Find(id);

            if (contact == null)
            {
                return BadRequest();
            }

            var userId = GetUserId();

            var entry = new ApplicationUserContact
            {
                ContactId = id,
                ApplicationUserId = userId
            };

            if (_context.ApplicationUserContacts.Contains(entry))
            {
                return RedirectToAction("All", "Contacts");
            }

            _context.ApplicationUserContacts.Add(entry);
            _context.SaveChanges();
            return RedirectToAction("All", "Contacts");
        }

        [Authorize]
        [HttpPost]
        public IActionResult RemoveFromTeam(int id)
        {
            var contact = _context.Contacts.Find(id);
            var userId = GetUserId();

            if (contact == null)
            {
                return BadRequest();
            }

            var entry = _context.ApplicationUserContacts.FirstOrDefault(um=>um.ApplicationUserId == userId && um.ContactId == id);
            
            _context.ApplicationUserContacts.Remove(entry);
            _context.SaveChanges();

            return RedirectToAction("Team", "Contacts");
        }

        [Authorize]
        public IActionResult Team()
        {
            var userId = GetUserId();

            var contacts = new AllContactModel()
            {
                Contacts = _context.ApplicationUserContacts
                    .Where(um => um.ApplicationUserId == userId)
                    .Select(um => new ContactViewModel
                    {
                        Id = um.Contact.Id,
                        FirstName = um.Contact.FirstName,
                        LastName = um.Contact.LastName,
                        Email = um.Contact.Email,
                        PhoneNumber = um.Contact.PhoneNumber,
                        Address = um.Contact.Address,
                        Website = um.Contact.Website
                    })
            };

            return View(contacts);
        }
    }
}

