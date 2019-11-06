using FluentValidation.AspNetCore;
using FluentValidationExample.Localization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace FluentValidationExample
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
            services.AddScoped<ILocalizer, Localizer>();

            //Use either one among Option 1, 2 and 3
            //Option 1
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<Startup>();
                });

            //Option 2
            //services.AddMvc().AddViewOptions(options => options.HtmlHelperOptions.ClientValidationEnabled = false).SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            //    .AddFluentValidation(fv =>
            //    {
            //        fv.RegisterValidatorsFromAssemblyContaining<Startup>();
            //    });

            ////Option 3
            //services.AddMvc().AddViewOptions(options => options.HtmlHelperOptions.ClientValidationEnabled = false).SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            //    .AddFluentValidation(fv =>
            //    {
            //        fv.RegisterValidatorsFromAssemblyContaining<Startup>();
            //        fv.ConfigureClientsideValidation(enabled: false);
            //    });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "Fluent Validation Example", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fluent Validation Example");
                c.RoutePrefix = string.Empty;
            });


            //app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fluent Validation Example"); });
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
