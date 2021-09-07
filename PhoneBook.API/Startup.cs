using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PhoneBook.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneBook.DAL.DataAccess;
using PhoneBook.API.Services.Abstract;
using PhoneBook.Utilities.ErrorLogging;

namespace PhoneBook.API
{
		public class Startup
		{
				public Startup(IConfiguration configuration)
				{
						Configuration = configuration;
				}

				public IConfiguration Configuration { get; }

				// This method gets called by the runtime. Use this method to add services to the container.
				public void ConfigureServices(IServiceCollection services)
				{
						var connection = Configuration.GetConnectionString("PhoneBook_Application");
						services.AddDbContext<ContactContext>(options => options.UseSqlServer(connection));

						services.AddCors(options =>
						{
								options.AddPolicy(name: "CorsPolicy",
																	builder =>
																	{
																			builder.WithOrigins("http://localhost:4200")
																			.AllowAnyHeader()
																			.AllowAnyMethod();
																	});
						});

						services.AddControllers();

						// Services
						services.AddScoped<IPhoneBookRepository, PhoneBookRepository>();
						services.AddScoped<IContactService, ContactService>();
						services.AddScoped<ILoggerManager, LoggerManager>();

						services.AddSwaggerGen(c =>
						{
								c.SwaggerDoc("v1", new OpenApiInfo { Title = "PhoneBook.API", Version = "v1" });
						});
				}

				// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
				public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
				{
						if (env.IsDevelopment())
						{
								app.UseDeveloperExceptionPage();
								app.UseSwagger();
								app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PhoneBook.API v1"));
						}

						app.UseHttpsRedirection();

						app.UseRouting();

						app.UseCors("CorsPolicy");

						app.UseAuthorization();

						app.UseEndpoints(endpoints =>
						{
								endpoints.MapControllers();
						});
				}
		}
}
