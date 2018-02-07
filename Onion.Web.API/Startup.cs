using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Onion.BLL.IServices.Books;
using Onion.BLL.Services.Books;
using System.Text;

namespace Onion.Web.API
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
            // When used with ASP.net core, add these lines to Startup.cs
            //var connectionString = Configuration.GetConnectionString("PHENIXContext");
            //services.AddEntityFrameworkNpgsql().AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
            var SigningKey = "jKQwDwKcutNWEndCiS1hM6GF7cdkr2T-exG_FuY41yg";
            //Configuration["SigningKey"]
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(jwtBearerOptions =>
            {
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateActor = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "PHENIX_NG",//Configuration["Issuer"],
                    ValidAudience = "60f783b666a94ec79a70b268e9a256df",//Configuration["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SigningKey))
                };
            });

            services.AddSingleton<IBookService, BookService>();
            services.AddCors();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseCors(builder =>
                builder.AllowAnyOrigin()
            );
            app.UseMvc();
        }
    }
}
