using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Modul4HomeWork4.Data;
using Modul4HomeWork4.Services.Abstractions;
using Modul4HomeWork4.Services;
using Modul4HomeWork4;
using Modul4HomeWork4.Repositories.Abstractions;
using Modul4HomeWork4.Repositories;

void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
{
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    serviceCollection.AddDbContextFactory<ApplicationDbContext>(opts
        => opts.UseSqlServer(connectionString));

    serviceCollection
        .AddScoped<IDbContextWrapper<ApplicationDbContext>, DbContextWrapper<ApplicationDbContext>>()
        .AddLogging(configure => configure.AddConsole())
        .AddTransient<ICategoryRepository, CategoryRepository>()
        .AddTransient<ICategoryService, CategoryService>()
        .AddTransient<ILocationRepository, LocationRepository>()
        .AddTransient<ILocationService, LocationService>()
        .AddTransient<IBreedRepository, BreedRepository>()
        .AddTransient<IBreedService, BreedService>()
        .AddTransient<IPetRepository, PetRepository>()
        .AddTransient<IPetService, PetService>()
        .AddTransient<App>();
}

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("config.json")
    .Build();

var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection, configuration);
var provider = serviceCollection.BuildServiceProvider();

var isNeedMigration = configuration.GetSection("Migration").GetValue<bool>("IsNeedMigration");

// It could be possible variant for production code
// BUT need to be careful and don't run extra migration
if (isNeedMigration)
{
    var dbContext = provider.GetService<ApplicationDbContext>();
    await dbContext!.Database.MigrateAsync();
}

var app = provider.GetService<App>();
await app!.StartAsync();