using ContactsAPI.Services;
using Microsoft.AspNetCore.Mvc;


namespace ContactsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IContactService _contactService;

        public ContactController(ILogger<ContactController> logger, IContactService contactService)
        {
            _logger = logger;
            _contactService = contactService;
        }
        
        [HttpGet(Name = "GetContact")]
        public ContactsDTO.Contact Get(string firstName, string lastName)
        {
            return _contactService.GetContactByName(firstName, lastName);    
        }

        [HttpPost(Name = "PostContact")]
        public ContactsDTO.Contact Post(ContactsDTO.Contact contact)
        {
            if(contact.Id == 0)
            {
                return _contactService.AddContact(contact);
            }
            else
            {
                return _contactService.UpdateContact(contact);
            }
        }
    }
}