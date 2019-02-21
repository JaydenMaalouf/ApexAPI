using System;
using System.Threading.Tasks;

using ApexLegendsAPI;

namespace ExampleTest
{
    class Program
    {
        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();
        public async Task MainAsync()
        {
            var API = new ApexAPI();
            var user = await API.GetUser("KangaaaOCE");
            var userStats = await user.GetStatsAsync();

            Console.WriteLine($"Username: {user.Name}");
            Console.WriteLine($"UserId: {user.UserId}");
            Console.WriteLine($"Current Legend: {user.CurrentLegend}");
            Console.WriteLine($"Platform: {user.Platform}");
            Console.Read();
        }
    }
}
