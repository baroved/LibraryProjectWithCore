using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ServerCoreLibrary.API;
using ServerCoreLibrary.DAL;
using ServerCoreLibrary.Repository.Service;
using ServerCoreLibrary.Repository.Api;
using ServerCoreLibrary.Services;
using Shared.BookResponse;
using ServerCoreLibrary.MangementPromotionService;
using Microsoft.AspNetCore.Internal;
using BusinessLogic.InputValidation;
using BusinessLogic.UserValidation;

namespace ServerCoreLibrary
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IItemsService, ItemsService>();
            services.AddScoped<IEditionService, EditionService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IItemsRepository, ItemRepository>();
            services.AddScoped<IEditionRepository, EditionRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<IPromotionRepository, PromotionsRepository>();
            services.AddScoped<IPromotionService, PromotionService>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<AddBookResponse>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IWriterRepository, WriterRepository>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<IWriterService, WriterService>();
            services.AddScoped<IBookGenreRepository, BookGenreRepository>();
            services.AddScoped<IBookGenreService, BookGenreService>();
            services.AddScoped<ValidationInputs>();
            services.AddScoped<UserValidation>();
            services.AddScoped<IPublisherDiscountRepository, PublisherDiscountRepository>();
            services.AddScoped<IDiscount, Discount>();
            services.AddScoped<IWriterDiscountRepository, WriterDiscountRepository>();
            services.AddScoped<IGenreDiscountRepository, GenreDiscountRepository>();
            services.AddScoped<IJournalRepository, JournalRepository>();
            services.AddScoped<IJournalService, JournalService>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookService>();



            services.AddDbContext<DBContext>(options =>
options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
