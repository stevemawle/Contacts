using ContactsDTO;
using ContactsAPI.Models;
using ContactsAPI.DataLayer;

namespace ContactsAPI.Mappers
{
    public class ContactMapper : IContactMapper
    {

        public ContactsDTO.Contact MapToDTOObject(Models.Contact contact) {  
        
            var contactDTO = new ContactsDTO.Contact();
            contactDTO.Id           = contact.Id;
            contactDTO.FirstName    = contact.FirstName;
            contactDTO.LastName     = contact.LastName;

            var addressDTO = new ContactsDTO.Address();
            addressDTO.Id           = contact.Address.Id;
            addressDTO.Line1        = contact.Address.Line1;
            addressDTO.Line2        = contact.Address.Line2;
            contactDTO.Address      = addressDTO;

            if (contact.Phone != null)
            {
                var phoneList = new List<ContactsDTO.Phone>();
                foreach (var item in contact.Phone)
                {
                    var phone = new ContactsDTO.Phone();
                    phone.Id = item.Id;
                    phone.Type = (ContactsDTO.Enums.PhoneType)item.Type;
                    phone.Prefix = item.Prefix;
                    phone.Number = item.Number;
                    phoneList.Add(phone);
                    
                }
                contactDTO.Phone = phoneList;
            }
            return contactDTO;
        }

        public Models.Contact MapToModelObject(ContactsDTO.Contact contact)
        {

            var contactModel = new Models.Contact();
            contactModel.Id         = contact.Id;
            contactModel.FirstName  = contact.FirstName;
            contactModel.LastName   = contact.LastName;

            var addressModel = new Models.Address();
            addressModel.Id         = contact.Address.Id;
            addressModel.Line1      = contact.Address.Line1;
            addressModel.Line2      = contact.Address.Line2;
            contactModel.Address    = addressModel;

            if (contact.Phone != null)
            {
                var phoneList = new List<Models.Phone>();
                foreach (var item in contact.Phone)
                {
                    var add = new Models.Phone();
                    add.Id = item.Id;
                    add.Prefix  = item.Prefix;
                    add.Number = item.Number;
                    add.Type = (Enums.PhoneType)item.Type;
                    phoneList.Add(add);
                }
                contactModel.Phone = phoneList;
            }

            return contactModel;
        }


    }

}
