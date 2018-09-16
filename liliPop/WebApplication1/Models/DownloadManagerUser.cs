namespace WebApplication1.Models
{
    public class DownloadManagerUser
    {
        public DownloadManagerUser(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; }

        public string Password { get; }
    }
}