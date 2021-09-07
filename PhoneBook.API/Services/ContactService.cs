
using PhoneBook.DAL.DataAccess;
using PhoneBook.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.API.Services.Abstract
{
		//A lot of the business logic will happen at this point 
		public class ContactService : IContactService
		{
				//I went with a repository design pattern seperate business logic from data access
				// the service layer does not need to know how or where the data comes from
				private readonly IPhoneBookRepository _phoneBookRepository ;
				public ContactService(IPhoneBookRepository phoneBookRepository)
				{
						_phoneBookRepository = phoneBookRepository;
				}
				public async Task<Contact> AddContact(Contact contact)
				{
						 await _phoneBookRepository.AddContact(contact);
						return contact;
				}

				public async Task<bool> DeleteContact(int id)
				{
						return await _phoneBookRepository.DeleteContact(id);
				}

				public async Task<List<PhoneBook.DAL.Models.PhoneBook>> GetAllContacts()
				{
						return await _phoneBookRepository.GetAllContacts();
				}

				public async Task<PhoneBook.DAL.Models.PhoneBook> GetPhoneBook(int phoneBook)
				{
						return await _phoneBookRepository.GetPhoneBook(phoneBook);
				}

				public async Task<PhoneBook.DAL.Models.PhoneBook> AddPhoneBook(PhoneBook.DAL.Models.PhoneBook phoneBook)
				{
						return await _phoneBookRepository.AddPhoneBook(phoneBook);
				}
				public async Task<Contact> GetContact(int id)
				{
						return await _phoneBookRepository.GetContact(id);
				}

				public async Task<Contact> UpdateContact(Contact contact)
				{
						if (contact.id != 0)
						{
								await _phoneBookRepository.UpdateContact(contact);
								return contact;
						}
						else
						{
								return null;
						}
				}
		}
}
