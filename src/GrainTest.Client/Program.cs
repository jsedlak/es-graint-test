using GrainTest.Common.Domains.Banking.Grains;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .UseOrleansClient(client =>
    {
        client.UseLocalhostClustering();
    })
    .UseConsoleLifetime()
    .Build();

await host.StartAsync();

var client = host.Services.GetRequiredService<IClusterClient>();

var accountId = Guid.Parse("5a672b7b-d39e-4afc-bfe0-a7f17ad3c521");
var account = client.GetGrain<IAccountGrain>(accountId);

Console.WriteLine($"Interacting with account {accountId}");
Console.WriteLine("[e]xit, [b]alance, [d]eposit, [w]ithdraw");

var running = true;
while (running)
{
    var input = Console.ReadLine();

    switch (input)
    {
        case "e":
            running = false;
            Console.WriteLine("Exiting...");
            break;
        case "b":
            var currentBalance = await account.GetBalance();
            Console.WriteLine($"Current Balance: {currentBalance:C}");
            break;
        case "w":
            Console.WriteLine("Enter amount to deposit:");
            if (double.TryParse(Console.ReadLine(), out var withdrawlAmount))
            {
                await account.Withdraw(withdrawlAmount);
                var balance = await account.GetBalance();
                Console.WriteLine($"New Balance: {balance:C}");
            }

            break;
        case "d":
            Console.WriteLine("Enter amount to deposit:");
            if (double.TryParse(Console.ReadLine(), out var depositAmount))
            {
                await account.Deposit(depositAmount);
                var balance = await account.GetBalance();
                Console.WriteLine($"New Balance: {balance:C}");
            }
            break;
    }
}

await host.StopAsync();

Console.WriteLine("Press [ENTER] to quit...");
Console.ReadLine();