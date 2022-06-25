using Alkoholspiel.WebApi;
using Alkoholspiel.WebApi.Database;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Xunit;

namespace Alkohospiel.WebUi.Tests;

public class IntegrationsTests : IClassFixture<WebApplicationFactory<Startup>>
    {
    private readonly HttpClient client;
    private readonly ApplicationDbContext givenDbContext;
    private readonly ApplicationDbContext assertDbContext;

    public IntegrationsTests(WebApplicationFactory<Startup> webApplicationFactory)
    {
        this.client = webApplicationFactory.CreateClient();
        IConfiguration configuration = webApplicationFactory.Services.GetService<IConfiguration>() ??
                                       throw new InvalidOperationException("Can't get Configuration from DI");

        givenDbContext = new ApplicationDbContext(GetOptionsForOtherDbContext(configuration));
        assertDbContext = new ApplicationDbContext(GetOptionsForOtherDbContext(configuration));
    }

    public DbContextOptions GetOptionsForOtherDbContext(IConfiguration configuration)
    {
        var builder = new NpgsqlConnectionStringBuilder
        {
            Host = configuration["DB_HOST"],
            Port = int.Parse(configuration["DB_PORT"]),
            Username = configuration["DB_USERNAME"],
            Password = configuration["DB_PASSWORD"],
            Database = configuration["DB_NAME"]
        };
        var options = new DbContextOptionsBuilder()
            .UseNpgsql(builder.ToString())
            .Options;
        return options;
    }
    
    
}