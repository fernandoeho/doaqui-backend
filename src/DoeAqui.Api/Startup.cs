using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoeAqui.Api.Configurations;
using DoeAqui.Infrastructure.Bus;
using DoeAqui.Infrastructure.Configuration;
using DoeAqui.Infrastructure.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace DoeAqui.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddJwt(_configuration);

            services.AddMvc();

            services.AddDomain();
            services.AddInfrastructure(_configuration);
            services.AddAppServices();

            services.AddCors();

            services.AddSwaggerDocumentation();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IHttpContextAccessor accessor)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseMvc();

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });

            app.UseSwaggerDocumentation();


            InMemoryBus.ContainerAccessor = () => accessor.HttpContext.RequestServices;
        }
    }
}
