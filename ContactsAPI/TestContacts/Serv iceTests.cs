using ContactsAPI.DataLayer;
using ContactsAPI.Enums;
using ContactsAPI.Mappers;
using ContactsAPI.Models;
using ContactsAPI.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace TestContacts
{
    public class ServiceTests
    {

        public ServiceTests()
        {
            var services = new ServiceCollection();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IContactMapper, ContactMapper>();
            services.AddTransient<IContactData, ContactData>();
            var serviceProvider = services.BuildServiceProvider();
        }

        [Test]
        public void TestAddContact()
        {
            //Arrange
            //Setup the objects we need 
            ContactsAPI.Models.Contact contactModel = new ContactsAPI.Models.Contact();
            contactModel.Id = 123;
            contactModel.FirstName = "Peter";
            contactModel.LastName = "Robinson";
            ContactsDTO.Contact contactDTO = new ContactsDTO.Contact();
            contactDTO.Id = 123;
            contactDTO.FirstName = "Peter";
            contactDTO.LastName = "Robinson";

            //Mock the calls the serivce will make
            var mockContactData = new Mock<IContactData>();
            mockContactData.Setup(mock => mock.AddContact(contactModel)).Returns(contactModel);
            var mockContactMapper = new Mock<IContactMapper>();
            mockContactMapper.Setup(mock => mock.MapToModelObject(contactDTO)).Returns(contactModel);
            mockContactMapper.Setup(mock => mock.MapToDTOObject(contactModel)).Returns(contactDTO);
            var sut = new ContactService(mockContactData.Object, mockContactMapper.Object);

            //Act
            var contact = sut.AddContact(contactDTO);

            //Assert
            Assert.IsNotNull(contact);
            Assert.That(contact.Id, Is.EqualTo(contactModel.Id));
            Assert.That(contact.FirstName, Is.EqualTo(contactModel.FirstName));
            Assert.That(contact.LastName, Is.EqualTo(contactModel.LastName));

        }

        [Ignore("WIP")]
        [Test]
        public void TestAddContact_Integration()
        {
            //Arrange
            //Setup the objects we need 
            ContactsAPI.Models.Contact contactModel = new ContactsAPI.Models.Contact();
            contactModel.Id = 123;
            contactModel.FirstName = "Peter";
            contactModel.LastName = "Robinson";
            
            Phone phone1 = new Phone() { Type = PhoneType.Mobile, Prefix = "+44", Number = "07563857447" };
            Phone phone2 = new Phone() { Type = PhoneType.Home, Prefix = "+44", Number = "0121568985" };
            contactModel.Phone = new List<Phone>() { phone1, phone2 };

            ContactsDTO.Contact contactDTO = new ContactsDTO.Contact();
            contactDTO.Id = 123;
            contactDTO.FirstName = "Peter";
            contactDTO.LastName = "Robinson";
            ContactsDTO.Phone phone3 = new ContactsDTO.Phone() { Type = ContactsDTO.Enums.PhoneType.Mobile, Prefix = "+44", Number = "07563857447" };
            ContactsDTO.Phone phone4 = new ContactsDTO.Phone() { Type = ContactsDTO.Enums.PhoneType.Home, Prefix = "+44", Number = "0121568985" };
            contactDTO.Phone = new List<ContactsDTO.Phone>() { phone3, phone4 };



            //Mock the calls the serivce will make
            var mockContactData = new Mock<IContactData>();
            mockContactData.Setup(mock => mock.AddContact(contactModel)).Returns(contactModel);
            var mockContactMapper = new Mock<IContactMapper>();
            mockContactMapper.Setup(mock => mock.MapToModelObject(contactDTO)).Returns(contactModel);
            mockContactMapper.Setup(mock => mock.MapToDTOObject(contactModel)).Returns(contactDTO);
            var sut = new ContactService(mockContactData.Object, mockContactMapper.Object);



            //Act
            var contact = sut.AddContact(contactDTO);

            //Assert
            Assert.IsNotNull(contact);
            Assert.That(contact.Id, Is.EqualTo(contactModel.Id));
            Assert.That(contact.FirstName, Is.EqualTo(contactModel.FirstName));
            Assert.That(contact.LastName, Is.EqualTo(contactModel.LastName));

        }
    }
}