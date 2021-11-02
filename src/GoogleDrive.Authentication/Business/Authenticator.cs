using System.ComponentModel.Composition;

namespace GoogleDrive.Authentication.Business
{
    [Export(typeof(IAuthenticator))]
    public class Authenticator : IAuthenticator
    {
        bool isAuthenticated = false;

        public bool IsAuthenticated()
        {
            return this.isAuthenticated;
        }

        public void LoadUserInfo()
        {
            // TODO: Need to check persistence data
        }

        public bool Login(string userName, string password)
        {
            // TODO: Call API to login / SSO
            this.isAuthenticated = true;
            return this.isAuthenticated;
        }
    }
}
