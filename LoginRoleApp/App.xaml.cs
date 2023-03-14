using LoginRoleApp.Common;
using LoginRoleApp.Services;
using LoginRoleApp.Views;
using Prism.Ioc;
using System;
using System.Windows;

namespace LoginRoleApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAuthenticationService, AuthenticationService>();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            UserPrincipial userPrincipial = new UserPrincipial();
            AppDomain.CurrentDomain.SetThreadPrincipal(userPrincipial);
            base.OnStartup(e);
        }
    }
}
