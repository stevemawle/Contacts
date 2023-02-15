using ContactsAPI.DB;
using ContactsAPI.Mappers;
using ContactsAPI.Models;
using ContactsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace ContactsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IContactService _contactService;

        public ContactsController(ILogger<ContactController> logger, IContactService contactService)
        {
            _logger = logger;
            _contactService = contactService;
        }

        [HttpGet(Name = "GetAllContacts")]
        public IEnumerable<ContactsDTO.Contact> GetAll()
        {
            return _contactService.GetContacts();

        }
    }
}