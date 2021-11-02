namespace GoogleDrive.Authentication.Business
{
    public interface IAuthenticator
    {
        bool IsAuthenticated();

        bool Login(string userName, string password);
        void LoadUserInfo();
    }
}
