using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Newtonsoft.Json;
using Reservations.Gateways.Subscriber;
using ReservationSystem.Config;
using ReservationSystem.Gateways.RestApi.Controllers.Reservations;
using Respect.Config.Autofac;

namespace ReservationSystem.Gateways.RestApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IServiceCollection Services { get; set; }

        private readonly ReservationsConfig _config;
        private readonly OptionConfig _optionConfig;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _config = Configuration.GetSection("ReservationsConfig").Get<ReservationsConfig>();
            _optionConfig = Configuration.GetSection("OptionConfig").Get<OptionConfig>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            SetAuthority(services);
            services.AddMvc(
                    options =>
                    {
                        var policy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()
                            .RequireScope("reservationSystem_api").Build();
                        options.Filters.Add(new AuthorizeFilter(policy));
                    }
                ).AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                .AddApplicationPart(typeof(ReservationsController).Assembly)
                .SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ReservationSystem.Gateways.RestApi", Version = "v1" });
            });
            Services = services;
        }
        private void SetAuthority(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = _optionConfig.AuthorityUri;
                    options.Audience = "reservationSystem_api";
                    options.RequireHttpsMetadata = false;
                });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var generalBootstrapperModule = new GeneralBootstrapperModule(_config.ConnectionString);
            var bootstrapperInventoryModule = new BootstrapperReservationsModule(_config.ConnectionString, "Reservations");
            builder.RegisterModule(generalBootstrapperModule).RegisterModule(bootstrapperInventoryModule);
            EndpointConfig.Config(generalBootstrapperModule, bootstrapperInventoryModule, Services);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ReservationSystem.Gateways.RestApi v1"));
            }
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
