using System;
using Alkoholspiel.Core;
using Alkoholspiel.WebApi.Database;
using Alkoholspiel.WebApi.Database.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Npgsql;

namespace Alkoholspiel.WebApi;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        ConfigureDbContext(services);

        services.AddScoped<IGameRepository, GameRepository>();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("AlkoholspielDocumentation", new OpenApiInfo()
            {
                Title = "Alkoholspiel API",
                Description = "Backend for Alkoholspiel",
                Version = "1",
                Contact = new OpenApiContact()
                {
                    Email = "arsene@lapostolet.fr",
                    Name = "Arsène Lapostolet",
                    Url = new Uri("https://arsenelapostolet.fr")
                },
                License = new OpenApiLicense()
                {
                    Name = "MIT License",
                    Url = new Uri("https://en.wikipedia.org/wiki/MIT_License")
                }
            });
        });

        services.AddControllersWithViews();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env /*ApplicationDbContext dataContext*/)
    {
        //dataContext.Database.Migrate();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();
        
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/AlkoholspielDocumentation/swagger.json", "Alkoholspiel API");
            options.RoutePrefix = "api/docs";
        });

        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");
            endpoints.MapFallbackToFile("index.html");
        });
    }

    private void ConfigureDbContext(IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(
            new NpgsqlConnectionStringBuilder
            {
                IncludeErrorDetail = true,
                Host = Configuration["DB_HOST"],
                Port = int.Parse(Configuration["DB_PORT"]),
                Username = Configuration["DB_USERNAME"],
                Password = Configuration["DB_PASSWORD"],
                Database = Configuration["DB_NAME"]
            }.ToString()));
    }
}