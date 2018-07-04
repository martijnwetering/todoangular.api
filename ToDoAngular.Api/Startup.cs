using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using ToDoAngular.Api.Contract;
using ToDoAngular.Api.Dtos;
using ToDoAngular.Api.Infrastructure;
using ToDoAngular.Api.Models;
using ToDoAngular.Api.Helpers;

namespace ToDoAngular.Api
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(setupAction =>
                {
                    //setupAction.ReturnHttpNotAcceptable = true;
                    //setupAction.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                    // setupAction.InputFormatters.Add(new XmlDataContractSerializerInputFormatter());

                    //var xmlDataContractSerializerInputFormatter =
                    //    new XmlDataContractSerializerInputFormatter();
                    //xmlDataContractSerializerInputFormatter.SupportedMediaTypes
                    //    .Add("application/vnd.marvin.authorwithdateofdeath.full+xml");
                    //setupAction.InputFormatters.Add(xmlDataContractSerializerInputFormatter);

                    //var jsonInputFormatter = setupAction.InputFormatters
                    //    .OfType<JsonInputFormatter>().FirstOrDefault();

                    //if (jsonInputFormatter != null)
                    //{
                    //    jsonInputFormatter.SupportedMediaTypes
                    //        .Add("application/vnd.marvin.author.full+json");
                    //    jsonInputFormatter.SupportedMediaTypes
                    //        .Add("application/vnd.marvin.authorwithdateofdeath.full+json");
                    //}

                    //var jsonOutputFormatter = setupAction.OutputFormatters
                    //    .OfType<JsonOutputFormatter>().FirstOrDefault();

                    //if (jsonOutputFormatter != null)
                    //{
                    //    jsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.marvin.hateoas+json");
                    //}

                })
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver =
                        new CamelCasePropertyNamesContractResolver();
                });
            services.AddDbContext<TodoAngularDbContext>(options =>
                options.UseSqlServer(_config["connectionStrings:defaultConnection"]));
            services.AddScoped<ITodoAngularUoW, TodoAngularTodoAngularUoW>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, TodoAngularDbContext todoAngularDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseStaticFiles();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TodoForCreationDto, Todo>();
                cfg.CreateMap<Todo, TodoDto>();
                cfg.CreateMap<TodoForUpdateDto, Todo>();
            });

            todoAngularDbContext.EnsureSeedDataForContext();
        }
    }
}
