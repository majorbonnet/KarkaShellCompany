using KarkaShellCompany.Blazor.Components;
using KarkaShellCompany.Blazor.Services;
using KarkaShellCompany.Domain;
using KarkaShellCompany.Domain.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);


builder.AddServiceDefaults();

var connectionString = builder.Configuration.GetConnectionString("karkashellco");
builder.Services.AddDbContextFactory<KarkaShellCompanyContext>(options =>
{
    options.UseNpgsql(connectionString)
        .UseSnakeCaseNamingConvention()
        .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
});

builder.EnrichNpgsqlDbContext<KarkaShellCompanyContext>();

builder.Services.AddDomainServices();
builder.Services.AddScoped<AdminService>();

builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddKeycloakOpenIdConnect(
        serviceName: "keycloak",
        realm: "karkashellco",
        authenticationScheme: OpenIdConnectDefaults.AuthenticationScheme,
        options =>
        {
            options.ClientId = "karkashellco-blazor";
            options.ClientSecret = builder.Configuration.GetValue<string>("Parameters:keycloak-clientsecret");
            options.ResponseType = OpenIdConnectResponseType.Code;
            options.RequireHttpsMetadata = false;
            options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        }
    )
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);

builder.Services.AddCascadingAuthenticationState();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
