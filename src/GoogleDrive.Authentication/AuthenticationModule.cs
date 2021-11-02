using GoogleDrive.Authentication.Business;
using Prism.Ioc;
using Prism.Modularity;

namespace GoogleDrive.Authentication
{
    public class AuthenticationModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton(typeof(IAuthenticator), typeof(Authenticator));
        }
    }
}
