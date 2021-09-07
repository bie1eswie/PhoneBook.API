using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.API.Helpers;
using PhoneBook.API.Services.Abstract;
using PhoneBook.DAL.Models;
using PhoneBook.Utilities.ErrorLogging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.API.Controllers
{
		[Route("api/[controller]")]
		[ApiController]
		[EnableCors("CorsPolicy")]
		public class ContactController : ControllerBase
		{
				private readonly IContactService _contactService;
				private readonly ILoggerManager _logger;
				public ContactController(IContactService contactService, ILoggerManager logger)
				{
						_contactService = contactService;
						_logger = logger;
				}
				[HttpPost("addNewContact")]
				public async Task<IActionResult> AddNewContact([FromBody] Contact contact)
				{
						GenericResult _result = new GenericResult();
						try
						{
								var result = await  _contactService.AddContact(contact);
								if (result !=null)
								{
										return Ok(new { Successfull = true, result = result, Message = "Contact added successfully" });
								}
								else
								{
										return BadRequest("There was a problem adding the contact");
								}
						}
						catch (Exception ex)
						{
								_result = new GenericResult()
								{
										Succeeded = false,
										Message = ex.Message
								};

								_logger.LogFatal(ex);
								return BadRequest(_result);
						}
				}

				[HttpPost("addNewPhoneBook")]
				public async Task<IActionResult> AddNewPhoneBook([FromBody] PhoneBook.DAL.Models.PhoneBook  phoneBook)
				{
						GenericResult _result = new GenericResult();
						try
						{
								var result = await _contactService.AddPhoneBook(phoneBook);
								if (result !=null)
								{
										return Ok(new { result = result, Message = "Phone book added successfully" });
								}
								else
								{
										return BadRequest("There was a problem adding the phone book");
								}
						}
						catch (Exception ex)
						{
								_result = new GenericResult()
								{
										Succeeded = false,
										Message = ex.Message
								};

								_logger.LogFatal(ex);
								return BadRequest(_result);
						}
				}


				[HttpPut("updateContact")]
				public async Task<IActionResult> UpdateContact([FromBody] Contact contact)
				{
						GenericResult _result = new GenericResult();
						try
						{
								var result = await _contactService.UpdateContact(contact);
								if (result != null)
								{
										return Ok(new { Successfull = true, result = result, Message = "Contact updated successfully" });
								}
								else
								{
										return BadRequest(new { Successfull = true, Message = "There was a problem updating the contact" });
								}
						}
						catch (Exception ex)
						{
								_result = new GenericResult()
								{
										Succeeded = false,
										Message = ex.Message
								};

								_logger.LogFatal(ex);
								return BadRequest(_result);
						}
				}
				[HttpDelete("{id}")]
				public async Task<IActionResult> Delete(int id)
				{
						GenericResult _result = new GenericResult();
						try
						{
								var result = await _contactService.DeleteContact(id);
								if (result == true)
								{
										return Ok(new { result, Message = "Contact deleted successfully" });
								}
								else
								{
										return BadRequest("There was a problem deleting the contact");
								}
						}
						catch (Exception ex)
						{
								_result = new GenericResult()
								{
										Succeeded = false,
										Message = ex.Message
								};

								_logger.LogFatal(ex);
								return BadRequest(_result);
						}
				}
				[HttpGet("getContacts")]
				public IActionResult GetContacts()
				{
						GenericResult _result = new GenericResult();
						try
						{
								var result = _contactService.GetAllContacts();
								if (result != null)
								{
										return Ok(new { result });
								}
								else
								{
										return Ok(_result = new GenericResult() { Message = "There were no contacts found", Succeeded = false });
								}
						}
						catch (Exception ex)
						{
								_result = new GenericResult()
								{
										Succeeded = false,
										Message = ex.Message
								};

								_logger.LogFatal(ex);
								return BadRequest(_result);
						}
				}
				[HttpGet("{id}")]
				public IActionResult Get(int id)
				{
						GenericResult _result = new GenericResult();
						try
						{
								var result = _contactService.GetContact(id);
								if (result != null)
								{
										return Ok(new { result });
								}
								else
								{
										return BadRequest("There was a problem getting the contact");
								}
						}
						catch (Exception ex)
						{
								_result = new GenericResult()
								{
										Succeeded = false,
										Message = ex.Message
								};

								_logger.LogFatal(ex);
								return BadRequest(_result);
						}
				}
		}
}
