using NBomber.Contracts;
using NBomber.CSharp;
using System.Net.Http;

namespace NBomberLoadTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var pageTests = new PageLoadTests();
            pageTests.Run();
        }

    }
}