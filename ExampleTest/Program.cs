using System;
using System.Threading.Tasks;

using ApexLegendsAPI;
using ApexLegendsAPI.Classes;

namespace ExampleTest
{
    class Program
    {
        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();
        public async Task MainAsync()
        {
            var API = new ApexAPI();
            if (API != null)
            {
                Console.WriteLine("API Ready!");

                var user = await API.GetUser("KangaaaOCE");
                if (user != null)
                {
                    Console.WriteLine($"Username: {user.Username}");
                    Console.WriteLine($"UserId: {user.UserId}");
                    Console.WriteLine($"Current Legend: {user.CurrentLegend}");
                    Console.WriteLine($"Platform: {user.Platform}");

                    var userStats = await user.GetStatsAsync();
                }

                var userById = await API.GetUser(Guid.Parse("f5337d769b7b29628f59d8c84ea45d9d"));
                if (userById != null)
                {
                    Console.WriteLine($"Username: {userById.Username}");
                    Console.WriteLine($"UserId: {userById.UserId}");
                    Console.WriteLine($"Current Legend: {userById.CurrentLegend}");
                    Console.WriteLine($"Platform: {userById.Platform}");

                    var userStats = await user.GetStatsAsync();
                }
            }
            Console.Read();
        }
    }
}
