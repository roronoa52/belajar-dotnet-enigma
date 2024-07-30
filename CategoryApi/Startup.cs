using Application.Services;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class Startup
{
	public void ConfigureServices(IServiceCollection services)
	{
		services.AddControllers();

		services.AddDbContext<ApplicationDbContext>(options =>
			options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

		services.AddScoped<ICategoryRepository>(provider =>
			new CategoryRepository(Configuration.GetConnectionString("DefaultConnection")));

		services.AddScoped<CategoryService>();
	}

	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		if (env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
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