using NBomber.Contracts;
using NBomber.CSharp;
using System.Net;
using System;

namespace NBomberLoadTest
{
    public class PageLoadTests
    {
        public void Run()
        {
            using var httpClient = new HttpClient();

            var step1 = Step.Create("step1", async context =>
            {
                var response = await httpClient.GetAsync("https://localhost:7217/Login/LoginUser", HttpCompletionOption.ResponseHeadersRead);

                return response.IsSuccessStatusCode
                    ? Response.Ok()
                    : Response.Fail();
            });

            var step2 = Step.Create("step2", async context =>
            {
                var response = await httpClient.GetAsync("https://localhost:7217/Login/LoginUser");

                return response.IsSuccessStatusCode
                    ? Response.Ok()
                    : Response.Fail();
            });

            var step3 = Step.Create("step3", async context =>
            {
                var response = await httpClient.GetAsync("https://localhost:7217/User/CreateUser");

                return response.IsSuccessStatusCode
                    ? Response.Ok()
                    : Response.Fail();
            });

            var step4 = Step.Create("step4", async context =>
            {
                var response = await httpClient.GetAsync("https://localhost:7217");

                return response.IsSuccessStatusCode
                    ? Response.Ok()
                    : Response.Fail();
            });

            var step5 = Step.Create("step5", async context =>
            {
                var response = await httpClient.GetAsync("https://localhost:7217/Profile/UserProfile");

                return response.IsSuccessStatusCode
                    ? Response.Ok()
                    : Response.Fail();
            });

            var step6 = Step.Create("step6", async context =>
            {
                var response = await httpClient.GetAsync("https://localhost:7217/Items/ReservedItemsList");

                return response.IsSuccessStatusCode
                    ? Response.Ok()
                    : Response.Fail();
            });

            var scenario = ScenarioBuilder
                .CreateScenario("simple_http1", step1)
                .WithWarmUpDuration(TimeSpan.FromSeconds(5))
                .WithLoadSimulations(Simulation.InjectPerSec(100, TimeSpan.FromSeconds(20)));
            var scenario1 = ScenarioBuilder
                .CreateScenario("simple_http2", step2)
                .WithWarmUpDuration(TimeSpan.FromSeconds(5))
                .WithLoadSimulations(Simulation.InjectPerSec(100, TimeSpan.FromSeconds(20)));
            var scenario2 = ScenarioBuilder
                .CreateScenario("simple_http3", step3)
                .WithWarmUpDuration(TimeSpan.FromSeconds(5))
                .WithLoadSimulations(Simulation.InjectPerSec(100, TimeSpan.FromSeconds(20)));
            var scenario3 = ScenarioBuilder
                .CreateScenario("simple_http4", step4)
                .WithWarmUpDuration(TimeSpan.FromSeconds(5))
                .WithLoadSimulations(Simulation.InjectPerSec(100, TimeSpan.FromSeconds(20)));
            var scenario4 = ScenarioBuilder
                .CreateScenario("simple_http5", step5)
                .WithWarmUpDuration(TimeSpan.FromSeconds(5))
                .WithLoadSimulations(Simulation.InjectPerSec(100, TimeSpan.FromSeconds(20)));

            NBomberRunner
                .RegisterScenarios(scenario, scenario1, scenario2, scenario3, scenario4)
                .Run();
        }
    }
}
