﻿namespace ContactsAPI.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Address Address { get; set; }
        public List<Phone> Phone { get; set; }
    }
}
