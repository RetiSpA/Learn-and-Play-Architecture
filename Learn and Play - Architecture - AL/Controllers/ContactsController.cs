using Learn_and_Play___Architecture___AL.VM;
using Learn_and_Play___Architecture___DAL;
using Learn_and_Play___Architecture___DAL.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Learn_and_Play___Architecture___AL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly AddressesContext _context;

        public ContactsController(AddressesContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetUserContacts()
        {
            var userContacts = _context.Users.Include("Contacts").ToList();
            return Ok(userContacts);
        }

        [HttpPost]
        [Route("CreateUser")]
        public IActionResult CreateUser(UserVM user)
        {
            User u = new()
            {
                Name = user.Name,
                Contacts = new List<Contact>()
                {
                    new Contact()
                    {
                        Type = user.Contacts.First().Type,
                        Value = user.Contacts.First().Value
                    }
                }
            };
            _context.Users.Add(u);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        [Route("CreateContact")]
        public IActionResult CreateContact([FromBody]Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var userToDelete = _context.Users.FirstOrDefault(user => user.Id == id);
            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteContact(int id)
        {
            var contactToDelete = _context.Contacts.FirstOrDefault(contact => contact.Id == id);
            if (contactToDelete != null)
            {
                _context.Contacts.Remove(contactToDelete);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}