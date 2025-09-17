using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
    .WithPgAdmin(pgAdmin => pgAdmin.WithHostPort(5665))
    .WithDataVolume("karkashellco-data");

var postgresdb = postgres.AddDatabase("karkashellco");

var keycloak = builder.AddKeycloak("keycloak", 6183)
    .WithDataVolume("karkashellco-keycloak-data");

var migrations = builder.AddProject<Projects.KarkaShellCompany_MigrationService>("migrations")
    .WithReference(postgresdb)
    .WaitFor(postgresdb);

var webapi = builder.AddProject<Projects.KarkaShellCompany_WebApi>("webapi")
    .WithReference(keycloak)
    .WithReference(postgresdb)
    .WithReference(migrations)
    .WaitForCompletion(migrations);

builder.AddProject<Projects.KarkaShellCompany_Blazor>("blazor")
    .WithReference(keycloak)
    .WithReference(postgresdb)
    .WithReference(migrations)
    .WaitForCompletion(migrations);

builder.Build().Run();
