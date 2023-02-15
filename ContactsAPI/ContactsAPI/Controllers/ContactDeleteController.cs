using ContactsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactDeleteController : ControllerBase
    {
        private readonly ILogger<ContactDeleteController> _logger;
        private readonly IContactService _contactService;

        public ContactDeleteController(ILogger<ContactDeleteController> logger, IContactService contactService)
        {
            _logger = logger;
            _contactService = contactService;
        }

        [HttpPost(Name = "DeleteContact")]
        public void Post(int id)
        {
            _contactService.DeletContactById(id);
        }
    }
}