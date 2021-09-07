using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.DAL.Models
{
		public class PhoneBook
		{
				[Key]
				public int id { get; set; }
				public string Name { get; set; }
				public List<Contact> Contacts { get; set; }
		}
}
