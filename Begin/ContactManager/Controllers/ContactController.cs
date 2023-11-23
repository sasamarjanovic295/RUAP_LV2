using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManager.Models;
using ContactManager.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactManager.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private ContactRepository contactRepository;

        public ContactController(IHttpContextAccessor httpContextAccessor)
        {
            this.contactRepository = new ContactRepository(httpContextAccessor);
        }

        [HttpGet]
        public Contact[] Get()
        {
            return contactRepository.GetAllContacts();
        }

        [HttpPost]
        public ActionResult Post(Contact contact)
        {
            this.contactRepository.SaveContact(contact);

            var response = CreatedAtAction(nameof(Post), contact);

            return response;
        }
    }
}