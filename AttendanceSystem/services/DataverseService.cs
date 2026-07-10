using Microsoft.PowerPlatform.Dataverse.Client;

namespace EmployeeManagement.Services
{
    public class DataverseService
    {
        public ServiceClient Connect()
        {
            string connectionString =
                "AuthType=OAuth;" +
                "Url=https://org27c592b8.crm8.dynamics.com/;" +
                "AppId=230791d2-abbc-48d2-b8fc-1685b9069c62;" +
                "RedirectUri=http://localhost;";

            return new ServiceClient(connectionString);
        }
    }
}