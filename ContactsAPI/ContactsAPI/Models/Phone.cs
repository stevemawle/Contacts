using ContactsAPI.Enums;

namespace ContactsAPI.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public PhoneType Type { get; set; }
        public string Prefix { get; set; }
        public string Number { get; set; }
    }
}
