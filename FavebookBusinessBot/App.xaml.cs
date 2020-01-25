using Dashboard1PrismTemplate.Views;
using Main;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace Dashboard1PrismTemplate
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<MainModule>();
        }
    }
}
