using AutoMapper;
using IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Filters;
using Presentation.Resources;
using UnprocessableEntityObjectResult = Presentation.ObjectResults.UnprocessableEntityObjectResult;

namespace Presentation
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
                {
                    options.Filters.Add<ActionFilter>();
                    options.Filters.Add<ExceptionFilter>();
                })
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider =
                        (type, factory) => factory.Create(typeof(ValidationMessages));
                })
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver =
                        new Newtonsoft.Json.Serialization.DefaultContractResolver();
                });
            
            services.AddAuthentication();
            
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory =
                    context => new UnprocessableEntityObjectResult(context.ModelState);
            });
            
            services.AddAutoMapper();
            services.ResolveDependencies(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseAuthentication();
        }
    }
}