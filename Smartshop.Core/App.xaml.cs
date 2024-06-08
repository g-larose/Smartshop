using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Smartshop.Core.Data;
using Smartshop.Core.Factories;
using Smartshop.Core.Interfaces;
using Smartshop.Core.Navigation;
using Smartshop.Core.ViewModels;
using System.Windows;

namespace Smartshop.Core
{
    /// <summary>
    /// This is created by the template
    /// make changes as needed
    /// Author: Async(void)
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton<LoginViewModel>();
                services.AddSingleton<AppDbContextFactory>();
                services.AddSingleton<INavigator, Navigator>();
                services.AddSingleton<LoginView>(s => new LoginView()
                {
                    DataContext = s.GetRequiredService<LoginViewModel>()
                });

            }).Build();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            await _host.StopAsync();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var LoginWindow = _host.Services.GetRequiredService<LoginView>();
            LoginWindow.Show();
            base.OnStartup(e);
        }
    }
}
