using Amazon.SQS;
using Api.Common;
using Application.Contracts;
using Application.Services;
using Application.Validators;
using Application.ViewModels;
using Data;
using Domain.Contracts;
using Domain.Messages;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Queue;

using System;

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

        


            services.AddMvc(opt =>
            {
                opt.Filters.Add(typeof(ValidatorActionFilter));
            }).AddFluentValidation();

            services.AddTransient<IValidator<CreateShortlinkViewModelRequest>, CreateShortlinkViewModelRequestValidator>();


            AmazonSQSConfig clientConfig = new AmazonSQSConfig();
            clientConfig.ServiceURL = Configuration.GetConnectionString("SqsConnection");
            AmazonSQSClient awsClient = new AmazonSQSClient(
                Configuration.GetConnectionString("AwsAccessKeyId"),
                Configuration.GetConnectionString("AwsSecretAccessKey"),
                clientConfig
            );


            services.AddSingleton<IAmazonSQS>(awsClient);
            services.AddScoped<IBaseQueue<ThirdPartyIntegration>, BaseQueue<ThirdPartyIntegration>>();

            services.AddEntityFrameworkNpgsql().AddDbContext<ShortlinkContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("ShortlinkDB")));

            services.AddScoped<IShortlinkRepository, ShortlinkRepository>();
            services.AddHttpClient<IShortlinkService, ShortlinkService>();
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
