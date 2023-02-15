using ContactsDTO;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ContactsAPI.Services
{
    public interface IContactService
    {
        public Contact GetContactById(int id);
        public List<ContactsDTO.Contact> GetContacts();
        public Contact GetContactByName(string firstName, string lastName);
        public Contact AddContact(Contact contact);
        public Contact UpdateContact(Contact contact);
        public int DeletContactById(int id);
    }
}
