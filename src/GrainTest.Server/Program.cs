using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using Petl.EventSourcing;
using Petl.EventSourcing.Providers;

await Host.CreateDefaultBuilder(args)
    .UseOrleans(silo =>
    {
        silo
            .ConfigureServices((services) =>
            {
                services.AddOrleansEventSerializer();
                services.AddDummyEventSourcing();
                //services.AddMongoEventSourcing("order-lake");
            })
            .UseLocalhostClustering();
            // .UseMongoDBClient(sp =>
            //     MongoClientSettings.FromConnectionString("mongodb://@localhost:27017/")
            // );
    })
    .RunConsoleAsync();