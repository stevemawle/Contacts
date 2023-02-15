using ContactsAPI.DB;
using ContactsAPI.Mappers;
using ContactsAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;

namespace ContactsAPI.DataLayer
{
    public class ContactData : IContactData
    {

        public Contact GetContactById(int id)
        {
            using (var context = new ContactsContext())
            {
                return (Contact)context.Contacts.Where(a => a.Id == id).First();
            }
        }


        public Contact GetContactByName(string firstName, string lastName)
        {
            using (var context = new ContactsContext())
            {
                return (Contact)context.Contacts.Where(a => a.FirstName == firstName && a.LastName == lastName).First();
            }
        }
        public Contact AddContact(Contact contact)
        {
            using (var context = new ContactsContext())
            {
                context.Contacts.Include("Address").Include("Phone").ToList();
                context.Add(contact);
                context.SaveChanges();

                //Get contact back from Db so we can get new id when we return it
                return (Contact)context.Contacts.Where(a => a.FirstName == contact.FirstName && a.LastName == contact.LastName).First();
            }

        }
        public Contact UpdateContact(Contact contact)
        {
            using (var context = new ContactsContext())
            {
                context.Update(contact);
                context.SaveChanges();
            }
            return contact;
        }
        
        public int DeleteContactById(int id)
        {
            using (var context = new ContactsContext())
            {
                var contact = context.Contacts.Where(a => a.Id == id).Include("Address").Include("Phone").First();
                context.Contacts.Remove(contact);
                return context.SaveChanges();
            }
        }

        public List<Contact> GetContacts()
        {
            using (var context = new ContactsContext())
            {
                return context.Contacts.Include("Address").Include("Phone").ToList();
            }
        }
    }
}
