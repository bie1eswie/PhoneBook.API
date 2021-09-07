using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.DAL.Models
{
		public class ContactContext : DbContext
		{
				public DbSet<Contact> Contacts { get; set; }
				public DbSet<PhoneBook> PhoneBooks { get; set; }
				public ContactContext(DbContextOptions<ContactContext> options) : base(options) { }
		}
}
