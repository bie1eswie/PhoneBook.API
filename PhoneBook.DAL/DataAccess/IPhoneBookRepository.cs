
using PhoneBook.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.DAL.DataAccess
{
		public interface IPhoneBookRepository
		{
				Task<bool> AddContact(Contact contact);
				Task<bool> DeleteContact(int id);
				Task<bool> UpdateContact(Contact contact);
				Task<List<PhoneBook.DAL.Models.PhoneBook>> GetAllContacts();
				Task<Contact> GetContact(int id);
				Task<PhoneBook.DAL.Models.PhoneBook> GetPhoneBook(int phoneBookID);
				Task<PhoneBook.DAL.Models.PhoneBook> AddPhoneBook(PhoneBook.DAL.Models.PhoneBook phoneBook);
		}
}
