using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Newtonsoft.Json;
using ReservationSyatem.Gateways.RestApi.Controllers.Reservations;
using ReservationSystem.Config;
using Respect.Config.Autofac;
using Notifications.Gateways.Subscriber;

namespace ReservationSyatem.Gateways.RestApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IServiceCollection Services { get; set; }

        private readonly ReservationsConfig _config;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _config = Configuration.GetSection("ReservationsConfig").Get<ReservationsConfig>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddMvc(
                    options =>
                    {
                        var policy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()
                            .RequireScope("reservationSystem_api").Build();
                        options.Filters.Add(new AuthorizeFilter(policy));
                    }
                ).AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                .AddApplicationPart(typeof(ReservationController).Assembly)
                .SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ReservationSyatem.Gateways.RestApi", Version = "v1" });
            });
            Services = services;
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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ReservationSyatem.Gateways.RestApi v1"));
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
