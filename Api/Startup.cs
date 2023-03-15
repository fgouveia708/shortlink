using Api.Common;
using Application.Contracts;
using Application.Services;
using Application.Validators;
using Application.ViewModels;
using Data;
using Data.Base;
using Domain;
using Domain.Contracts;
using Domain.Messages;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Queue;
using Queue.Base;

namespace Api
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

            services.AddDocumentationApi();

            services.Configure<Configurations>(Configuration.GetSection("Configurations"));

            services.AddMvc(opt =>
            {
                opt.Filters.Add(typeof(ValidatorActionFilter));
            }).AddFluentValidation();

                      
            services.AddTransient<IValidator<CreateShortlinkViewModelRequest>, CreateShortlinkViewModelRequestValidator>();

            services.AddScoped<IBaseQueue<ThirdPartyIntegration>, BaseQueue<ThirdPartyIntegration>>();

            services.AddEntityFrameworkNpgsql().AddDbContext<ShortlinkContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("ShortlinkDB")));

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IShortlinkService, ShortlinkService>();
            services.AddScoped<IThirdPartyIntegrationQueue, ThirdPartyIntegrationQueue>();

            services.AddControllers().AddNewtonsoftJson();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDocumentationApi();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
