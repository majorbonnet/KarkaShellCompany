using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
    .WithPgAdmin(pgAdmin => pgAdmin.WithHostPort(5665))
    .WithDataVolume("karkashellco-data");
var postgresdb = postgres.AddDatabase("karkashellco");

var webapi = builder.AddProject<Projects.KarkaShellCompany_WebApi>("webapi")
    .WithReference(postgresdb)
    .WaitFor(postgresdb);

builder.AddProject<Projects.KarkaShellCompany_Blazor>("blazor")
    .WithExternalHttpEndpoints()
    .WithReference(webapi)
    .WaitFor(webapi);

builder.Build().Run();
