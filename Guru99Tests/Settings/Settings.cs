using System.Xml;

namespace Guru99Tests.Settings
{
    public static class Settings
    {
        public static string file = "Settings.xml";
        private static XmlDocument document;

        private static string baseURL;
        private static string login;
        private static string password;

        static Settings()
        {
            string path = Path.Combine(TestContext.CurrentContext.TestDirectory, file);
            if (!File.Exists(path))
            {
                throw new Exception("Problem: settings file not found: " + path);
            }
            
            document = new XmlDocument();
            document.Load(path);
        }

        public static string BaseURL
        {
            get
            {
                if (baseURL == null)
                {
                    baseURL = document.DocumentElement.SelectSingleNode("BaseUrl").InnerText;
                }
                return baseURL;
            }
        }

        public static string Login
        {
            get
            {
                if (login == null)
                {
                    login = document.DocumentElement.SelectSingleNode("Login").InnerText;
                }
                return login;
            }
        }

        public static string Password
        {
            get
            {
                if (password == null)
                {
                    password = document.DocumentElement.SelectSingleNode("Password").InnerText;
                }
                return password;
            }
        }
    }
}