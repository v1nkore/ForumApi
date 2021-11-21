using System.Text;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace KudryavtsevAlexey.Forum.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ForumDbContext>(config => config.UseSqlServer(Configuration.GetConnectionString("ForumDb")));
			services.AddAuthentication("OAuth2.0")
				.AddJwtBearer("OAuth2.0", config =>
			   {
				   byte[] bytes = Encoding.UTF8.GetBytes(Constants.SecretKey);

				   var key = new SymmetricSecurityKey(bytes);

				   config.TokenValidationParameters = new TokenValidationParameters()
				   {
					   ValidIssuer = Constants.Issuer,
					   ValidAudience = Constants.Audience,
					   IssuerSigningKey = key,
				   };
			   });

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "ForumApi", Version = "v1" });
			});
			services.AddControllers();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}