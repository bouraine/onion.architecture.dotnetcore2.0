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
            #region Hide
            // When used with ASP.net core, add these lines to Startup.cs
            //var connectionString = Configuration.GetConnectionString("OnionContext");
            //services.AddEntityFrameworkNpgsql().AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
            #endregion

            string Issuer = Configuration.GetSection("AuthCredentials").GetSection("Issuer").Value;
            string Audience = Configuration.GetSection("AuthCredentials").GetSection("Audience").Value;
            string SigningKey = Configuration.GetSection("AuthCredentials").GetSection("SigningKey").Value;

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(jwtBearerOptions =>
            {
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateActor = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Issuer,
                    ValidAudience =Audience,
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
            //don't use on production env
            app.UseCors(builder =>
                builder.AllowAnyOrigin()
            );
            app.UseMvc();
        }
    }
}
