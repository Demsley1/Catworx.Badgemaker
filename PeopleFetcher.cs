using System.Net;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;

namespace CatWorx.BadgeMaker {
    
    class PeopleFetcher
    {
        private static readonly HttpClient client = new HttpClient();
        public static List<Employee> GetEmployees()
        {
            
            // I will return a List of strings
            List<Employee> employees = new List<Employee>();
            // Collect user values until the value is an empty string while (true)
            while (true)
            {
                Console.WriteLine("Please enter a name (Leave empty to exit):");
                string firstName = Console.ReadLine();
                // Break if the user hits ENTER without typing a name, or if firstName, lastName, or photoUrl is equal to null values
                if(firstName == "" || firstName == null)
                {
                    break;
                }
                Console.Write("Enter last name: ");
                string lastName = Console.ReadLine();
                Console.Write("Enter ID: ");
                int id = Int32.Parse(Console.ReadLine());
                Console.Write("Enter Photo URL: ");
                string photoUrl = Console.ReadLine();

                if(lastName == null || photoUrl == null)
                {
                    break;
                }

                // Create a new Employee instance
                Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
                // Add currentEmployee, not a string
                employees.Add(currentEmployee);
            }

            // marked importante!!!!
            return employees;
        }

        
        public static async Task<List<Employee>>  GetFromAPI()
        {
            List<Employee> employees = new List<Employee>();
            string response = await client.GetStringAsync("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");
            JObject json = JObject.Parse(response);

            
            
            foreach (JToken token in json.SelectToken("results"))
            {
                Employee emp = new Employee
                (
                    token.SelectToken("name.first").ToString(),
                    token.SelectToken("name.last").ToString(),
                    Int32.Parse(token.SelectToken("id.value").ToString().Replace("-", "")),
                    token.SelectToken("picture.large").ToString()
                );

                employees.Add(emp);
            }

            return await Task.FromResult( employees );
            
            // List<Employee> employees = new List<Employee>();
            // string response = await client.GetStringAsync("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");
        }
        
    }
}