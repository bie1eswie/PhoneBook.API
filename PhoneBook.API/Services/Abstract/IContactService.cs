
using PhoneBook.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.API.Services.Abstract
{
		public interface IContactService
		{
				Task<Contact> AddContact(Contact contact);
				Task<bool> DeleteContact(int id);
				Task<Contact> UpdateContact(Contact contact);
				Task<List<PhoneBook.DAL.Models.PhoneBook>> GetAllContacts();
				Task<Contact> GetContact(int id);
				Task<PhoneBook.DAL.Models.PhoneBook> GetPhoneBook(int phoneBook);
				Task<PhoneBook.DAL.Models.PhoneBook> AddPhoneBook(PhoneBook.DAL.Models.PhoneBook phoneBook);

		}
}
