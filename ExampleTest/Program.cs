using ApexLegendsAPI;
using ApexLegendsAPI.Classes;
using System;
using System.Threading.Tasks;

namespace ExampleTest
{
    class Program
    {
        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();
        public async Task MainAsync()
        {
            var a = new ApexAPI();
            var b = await a.GetUser("KangaaaOCE");
            var c = await b.GetStatsAsync();
            Console.WriteLine("Hello World!");
        }
    }
}
