using ContactsAPI.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ContactsAPI.DataLayer
{
    public interface IContactData
    {
        public Contact GetContactById(int id);
        public List<Contact> GetContacts();
        public Contact GetContactByName(string firstName, string lastName);
        public Contact AddContact(Contact contact);
        public Contact UpdateContact(Contact contact);
        public int DeleteContactById(int id);
    }
}
