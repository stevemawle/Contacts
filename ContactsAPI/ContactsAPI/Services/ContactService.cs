using ContactsAPI.DB;
using ContactsAPI.Mappers;
using ContactsDTO;
using ContactsAPI.DataLayer;
using ContactsAPI.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ContactsAPI.Controllers;

namespace ContactsAPI.Services
{
    public class ContactService : IContactService
    {
        //private readonly ILogger<ContactService> _logger;
        private readonly IContactData _contactData;
        private readonly IContactMapper _contactMappper;

        public ContactService(IContactData contactData, IContactMapper contactMappper)//ILogger<ContactService> logger)
        {
            //_logger = logger;
            _contactData = contactData;
            _contactMappper = contactMappper;
        }
        public ContactsDTO.Contact AddContact(ContactsDTO.Contact contact)
        {
            var contactModel  = _contactMappper.MapToModelObject(contact);
            var newContact = _contactData.AddContact(contactModel);
            return _contactMappper.MapToDTOObject(newContact);
        }

        public int DeletContactById(int id)
        {
            return _contactData.DeleteContactById(id);
        }

        public ContactsDTO.Contact GetContactById(int id)
        {
            var contact =  _contactData.GetContactById(id);
            return _contactMappper.MapToDTOObject(contact);
        }

        public ContactsDTO.Contact GetContactByName(string firstName, string lastName)
        {
            var contact = _contactData.GetContactByName(firstName,lastName);
            return _contactMappper.MapToDTOObject(contact);
        }

        public List<ContactsDTO.Contact> GetContacts()
        {
            var contacts = _contactData.GetContacts();
            ContactMapper mapper = new ContactMapper();

            List<ContactsDTO.Contact> contactsDTO = new List<ContactsDTO.Contact>();
            foreach (var contact in contacts)
            {
                contactsDTO.Add(mapper.MapToDTOObject(contact));
            }

            return contactsDTO;

        }
        public ContactsDTO.Contact UpdateContact(ContactsDTO.Contact contact)
        {
            var contactModel = _contactMappper.MapToModelObject(contact);
            var newContact = _contactData.UpdateContact(contactModel);
            return _contactMappper.MapToDTOObject(newContact);
        }
    }
}
