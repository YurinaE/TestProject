using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using TestProject.Application;
using TestProject.Data;

namespace TestProject;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : System.Windows.Application
{
    private readonly ServiceProvider _serviceProvider;

    public App()
    {
        var serviceCollection = new ServiceCollection();

        ConfigureServices(serviceCollection);

        _serviceProvider = serviceCollection.BuildServiceProvider();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContextFactory<TestDbContext>(options =>
        {
            options.EnableSensitiveDataLogging(true);
            options.EnableDetailedErrors();
        }, ServiceLifetime.Transient);
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(InsertMessageDataHandler).Assembly));
        services.AddTransient<IParseService, ParseService>();
        services.AddTransient<MainWindow>();
    }

    private void OnStartup(object sender, StartupEventArgs e)
    {
        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();

        mainWindow.Show();
    }
}
