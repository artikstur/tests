using Guru99Tests.Data;
using System.Xml.Serialization;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            string filename = args[1];
            string format = args[2];

            List<CustomerData> customers = new List<CustomerData>();
            for (int i = 0; i < count; i++)
            {
                customers.Add(new CustomerData(GenerateRandomString(7))
                {
                    Dob = "01042026",
                    Address = GenerateRandomString(15),
                    City = GenerateRandomString(8),
                    State = GenerateRandomString(8),
                    Pin = "123123",
                    Mobile = "123456789",
                    Email = GenerateRandomString(6) + "@email.ru",
                    Password = "pass"
                });
            }

            if (format == "xml")
            {
                WriteToXmlFile(customers, filename);
            }
            else
            {
                Console.WriteLine("Unrecognized format: " + format);
            }
        }

        static void WriteToXmlFile(List<CustomerData> customers, string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<CustomerData>));
            using (StreamWriter writer = new StreamWriter(filename))
            {
                serializer.Serialize(writer, customers);
            }
        }

        static string GenerateRandomString(int max)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ";
            Random rnd = new Random();
            string result = "";
            for (int i = 0; i < rnd.Next(3, max); i++)
            {
                result += chars[rnd.Next(chars.Length)];
            }
            return result.Trim();
        }
    }
}
