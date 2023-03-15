using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Diagnostics;
using System.Reflection;


namespace Api.Common
{
    public static class DocumentationApiExtension
    {
        private static IApiVersionDescriptionProvider _provider;

        public static void AddDocumentationApi(this IServiceCollection services)
        {
            services.AddVersionedApiExplorer();

            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services.AddVersionedApiExplorer(p =>
            {
                p.GroupNameFormat = "'v'VVV";
                p.SubstituteApiVersionInUrl = true;
            });

            _provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

            services.AddSwaggerGen(c =>
            {

                foreach (var description in _provider.ApiVersionDescriptions)
                    c.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
            });

            services.AddSwaggerGenNewtonsoftSupport();
        }

        private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Title = $"Shortlink {description.ApiVersion}",
                Version = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion
            };

            if (description.IsDeprecated) info.Description += " This API version is deprecated";

            return info;
        }

        public static IApplicationBuilder UseDocumentationApi(this IApplicationBuilder app)
        {
            app.UseApiVersioning();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                foreach (var description in _provider.ApiVersionDescriptions)
                    options.SwaggerEndpoint($"./swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());

                options.DocExpansion(DocExpansion.List);

                options.RoutePrefix = string.Empty;
            });

            return app;
        }
    }
}