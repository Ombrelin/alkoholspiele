using System.Net;
using System.Net.Http.Json;
using Alkoholspiel.Core.Contracts;
using Alkoholspiel.Core.Entities;
using Alkoholspiel.WebApi.Database;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Xunit;
using FluentAssertions;

namespace Alkoholspiel.WebApi.Tests;

public class IntegrationsTests : IClassFixture<WebApplicationFactory<Startup>>, IAsyncLifetime
{
    private readonly TestcontainerDatabase database = new TestcontainersBuilder<PostgreSqlTestcontainer>()
        .WithDatabase(new PostgreSqlTestcontainerConfiguration
        {
            Database = "db",
            Username = "postgres",
            Password = "postgres",
        })
        .Build();

    private readonly IConfiguration configuration;

    private WebApplicationFactory<Startup> webApplicationFactory;
    protected HttpClient client;
    protected ApplicationDbContext givenDbContext;
    protected ApplicationDbContext assertDbContext;

    public IntegrationsTests(WebApplicationFactory<Startup> webApplicationFactory)
    {
        this.webApplicationFactory = webApplicationFactory;

    }

    public DbContextOptions GetOptionsForOtherDbContext(IConfiguration configuration)
    {
        var options = new DbContextOptionsBuilder()
            .UseNpgsql(this.database.ConnectionString)
            .Options;
        return options;
    }
    
    public async Task InitializeAsync()
    {
        await this.database.StartAsync();
        this.webApplicationFactory = webApplicationFactory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureAppConfiguration((_,config) =>
            {
                config.AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["DB_HOST"] = this.database.Hostname,
                    ["DB_PORT"] = this.database.Port.ToString(),
                    ["DB_USERNAME"] = this.database.Username,
                    ["DB_PASSWORD"] = this.database.Password,
                    ["DB_NAME"] = this.database.Database
                });
            });
        });
        this.client = webApplicationFactory.CreateClient();

        givenDbContext = new ApplicationDbContext(GetOptionsForOtherDbContext(configuration));
        assertDbContext = new ApplicationDbContext(GetOptionsForOtherDbContext(configuration));
    }

    public async Task DisposeAsync()
    {
        await this.givenDbContext.DisposeAsync();
        await this.assertDbContext.DisposeAsync();
        await this.database.DisposeAsync().AsTask();
    }
}