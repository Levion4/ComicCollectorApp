using ComicCollectorApp.Core.Services;
using ComicCollectorApp.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace ComicCollectorApp.View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IFileDialogService, FileDialogService>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<MainWindow>();
        }
    }
}
