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
            if (API != null)
            {
                Console.WriteLine("API Ready!");

                var user = await API.GetUserAsync("KangaaaOCE");
                if (user != null)
                {
                    Console.WriteLine($"Username: {user.Username}");
                    Console.WriteLine($"UserId: {user.UserId}");
                    Console.WriteLine($"Current Legend: {user.CurrentLegend}");
                    Console.WriteLine($"Platform: {user.Platform}");

                    var userStats = await user.GetStatsAsync();
                    var currentLegendStats = userStats.GetCurrentLegendStats();
                    var lifelineLegendStats = userStats.GetLegendStats(ApexLegendsAPI.Enums.ApexLegendType.Lifeline);
                }

                var userById = await API.GetUserAsync(Guid.Parse("f69f266bae0891b851a9c3c7f76d4323"));
                if (userById != null)
                {
                    Console.WriteLine($"Username: {userById.Username}");
                    Console.WriteLine($"UserId: {userById.UserId}");
                    Console.WriteLine($"Current Legend: {userById.CurrentLegend}");
                    Console.WriteLine($"Platform: {userById.Platform}");

                    var userStats = await userById.GetStatsAsync();

                    var todaysStats = userStats.GetStatsToday();

                    var yesterday = DateTime.UtcNow.Date.AddDays(-1);
                    var yesterdaysStats = userStats.GetStatsFrom(yesterday);
                }
            }
            Console.Read();
        }
    }
}
