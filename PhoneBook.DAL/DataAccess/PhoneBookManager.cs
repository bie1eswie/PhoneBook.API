
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using PhoneBook.DAL.Models;
using PhoneBook.Utilities.ErrorLogging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace PhoneBook.DAL.DataAccess
{
		public class PhoneBookRepository : IPhoneBookRepository
		{
				private readonly ContactContext _contactContext;
				private readonly ILoggerManager _logger;

				public PhoneBookRepository(ContactContext contactContext, ILoggerManager logger)
				{
						_contactContext = contactContext;
						_logger = logger;
				}
				public async Task<bool> AddContact(Contact contact)
				{
						try
						{
										await _contactContext.Contacts.AddAsync(contact);
										return await _contactContext.SaveChangesAsync() > 0;
						}
						catch (Exception ex)
						{
								_logger.LogFatal(ex);
								return false;
						}
				}

				public async Task<Models.PhoneBook> AddPhoneBook(Models.PhoneBook phoneBook)
				{
						try
						{
								_contactContext.PhoneBooks.Add(phoneBook);
								await _contactContext.SaveChangesAsync();
								return phoneBook;
						}
						catch (Exception ex)
						{
								_logger.LogFatal(ex);
								return null;
						}
				}

				public async Task<bool> DeleteContact(int id)
				{
						try
						{
										var contact = _contactContext.Contacts.FirstOrDefault(x => x.id == id);
										if (contact != null)
										{
												_contactContext.Contacts.Remove(contact);
										}
										return await _contactContext.SaveChangesAsync() > 0;
						}
						catch (Exception ex)
						{
								_logger.LogFatal(ex);
								return false;
						}
				}

				public async Task<List<PhoneBook.DAL.Models.PhoneBook>> GetAllContacts()
				{
						try
						{
									var item = (from a in _contactContext.PhoneBooks
														 select a).Include(x=>x.Contacts);
								return  await item.ToListAsync();
						}
						catch (Exception ex)
						{
								_logger.LogFatal(ex);
								return null;
						}
				}

				public async Task<Contact> GetContact(int id)
				{
						try
						{
										return await  _contactContext.Contacts.SingleOrDefaultAsync(x=>x.id==id);
						}
						catch (Exception ex)
						{
								_logger.LogFatal(ex);
								return null;
						}
				}

				public async Task<PhoneBook.DAL.Models.PhoneBook> GetPhoneBook(int phoneBookID)
				{
						return await _contactContext.PhoneBooks.SingleOrDefaultAsync(x => x.id == phoneBookID);
				}

				public async Task<bool> UpdateContact(Contact contact)
				{
						try
						{
										_contactContext.Contacts.Update(contact);
										return await _contactContext.SaveChangesAsync() > 0;
						}
						catch (Exception ex)
						{
								_logger.LogFatal(ex);
								return false;
						}
				}
		}
}
