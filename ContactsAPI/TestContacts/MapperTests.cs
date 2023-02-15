using ContactsAPI.Mappers;
using ContactsAPI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace TestContacts
{
    public class MapperTests
    {
        private readonly IContactMapper? _contactMapper;

        public MapperTests()
        {
            var services = new ServiceCollection();
            services.AddTransient<IContactMapper, ContactMapper>();
            var serviceProvider = services.BuildServiceProvider();
            _contactMapper = serviceProvider.GetService<IContactMapper>();
        }

        [Test]
        public void TestContactMapToDTOMapper()
        {
            //Arrange
            ContactsAPI.Models.Contact contactModel = new ContactsAPI.Models.Contact();
            contactModel.Id = 123;
            contactModel.FirstName = "Peter";
            contactModel.LastName = "Robinson";
            var addressDTO = new ContactsAPI.Models.Address();
            addressDTO.Id = 1;
            addressDTO.Line1 = "25 Miller street";
            addressDTO.Line1 = "London";
            contactModel.Address = addressDTO;
            var phone = new ContactsAPI.Models.Phone();
            phone.Id = 1;
            phone.Prefix = "+44";
            phone.Number = "01235478545";
            var addList = new List<ContactsAPI.Models.Phone>();
            addList.Add(phone);
            contactModel.Phone = addList;

            //Act
            ContactsDTO.Contact contactDTO = new ContactsDTO.Contact();
            contactDTO = _contactMapper.MapToDTOObject(contactModel);

            //Assert
            Assert.IsNotNull(contactDTO);
            Assert.That(contactDTO.Id, Is.EqualTo(contactModel.Id));
            Assert.That(contactDTO.FirstName, Is.EqualTo(contactModel.FirstName));
            Assert.That(contactDTO.LastName, Is.EqualTo(contactModel.LastName));

        }

        [Test]
        public void TestContactMapToModelMapper()
        {
            //Arrange
            ContactsDTO.Contact contactDTO = new ContactsDTO.Contact();
            contactDTO.Id = 456;
            contactDTO.FirstName = "Fred";
            contactDTO.LastName = "Flinstone";
            var addressDTO = new ContactsDTO.Address();
            addressDTO.Id = 1;
            addressDTO.Line1 = "25 Miller street";
            addressDTO.Line1 = "London";
            contactDTO.Address = addressDTO;
            var phone = new ContactsDTO.Phone();
            phone.Id = 1;
            phone.Prefix = "+44";
            phone.Number = "01235478545";
            var addList = new List<ContactsDTO.Phone>();
            addList.Add(phone);
            contactDTO.Phone = addList;

            //Act
            ContactsAPI.Models.Contact contactModel = new ContactsAPI.Models.Contact();
            contactModel = _contactMapper.MapToModelObject(contactDTO);

            //Assert
            Assert.IsNotNull(contactModel);
            Assert.That(contactModel.Id, Is.EqualTo(contactDTO.Id));
            Assert.That(contactModel.FirstName, Is.EqualTo(contactDTO.FirstName));
            Assert.That(contactModel.LastName, Is.EqualTo(contactDTO.LastName));

        }
    }
}