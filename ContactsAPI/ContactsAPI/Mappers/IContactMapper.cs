namespace ContactsAPI.Mappers
{
    public interface IContactMapper
    {
        public ContactsDTO.Contact MapToDTOObject(Models.Contact contact);
        public Models.Contact MapToModelObject(ContactsDTO.Contact contact);
    }
}
