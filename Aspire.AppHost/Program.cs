using Aspire.Hosting;
using Microsoft.Extensions.Configuration;



var builder = DistributedApplication.CreateBuilder(args);
var sql = builder.AddSqlServer("sqldb");
//another way to connect
var connectionString = builder.AddConnectionString("AspireAPI");
//var sqldb = sql.AddDatabase("AspireAPI");

var apiService = builder.AddProject<Projects.Aspire_ApiService>("apiservice").WithReference(sql).WithReference(connectionString);

builder.AddProject<Projects.Aspire_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
