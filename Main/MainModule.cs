using Main.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Main
{
    public class MainModule : IModule
    {

        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(AccountManager));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Bot>();
            containerRegistry.RegisterForNavigation<AccountManager>();
            containerRegistry.RegisterForNavigation<Settings>();
            containerRegistry.RegisterForNavigation<AdvCompany>();
            containerRegistry.RegisterForNavigation<PageManager>();
            containerRegistry.RegisterForNavigation<ViewA>();
        }
    }
}