using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Gcsb.Connect.Pkg.Serilog.Implementation;
using Gcsb.Connect.SAP.WebApi.Config.DependenceInjection;
using Gcsb.Connect.SAP.WebApi.Pipeline;
using Gcsb.Connect.SAP.WebApi.Resources;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.AddAutofacRegistration());

builder.Services.AddJwtToken();
builder.Services.Cors();
builder.Services.SwaggerDocument();
builder.Services.AddLocalization();
builder.Services.AddProblemDetails();
builder.Services.AddFilters();
builder.Services.AddHealthCheck();
builder.Services.AddHttpClientServices();
builder.Services.AddOptions();
builder.Services.AddMvc(o => o.EnableEndpointRouting = false)
    .AddNewtonsoftJson(options => options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter()))
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter()));

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var app = builder.Build();
var resources = ((IApplicationBuilder)app).ApplicationServices.GetService<IStringLocalizer<ReturnMessages>>();
var env = app.Services.GetRequiredService<IWebHostEnvironment>();

app.UseExceptionHandler(new ExceptionHandlerOptions
{
    ExceptionHandler = new ErrorHandlerMiddleware(env, resources).Invoke
});

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseMiddleware<RequestResponseLoggingMiddleware>();
app.UseMiddleware();
app.UseCors();
app.AddLocalization();
app.UseHealthCheck();
app.UseProblemDetails();
app.UseAuthentication();
app.Swagger();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(e => e.MapControllers());
app.AddOptions();

app.Run();
