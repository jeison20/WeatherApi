using Weather.Application;
using Weather.Domain;
using Weather.Services;
using Microsoft.EntityFrameworkCore;
using Polly;
using Weather.EFCore;
using Weather.EFCore.DataContext;
using Microsoft.AspNetCore.Diagnostics;
using WeatherApi.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddDomain();
builder.Services.AddServices();
builder.Services.AddPersistence(builder.Configuration, "DbConection");

builder.Services.AddDbContext<WeatherContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DbConection"], sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
        maxRetryCount: 2,
        maxRetryDelay: TimeSpan.FromSeconds(50),
        errorNumbersToAdd: null);
    });
});

var httpRetryPolicy = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode).WaitAndRetryAsync(2, retryAttempt => TimeSpan.FromSeconds(50));

builder.Services.AddSingleton<IAsyncPolicy<HttpResponseMessage>>(httpRetryPolicy);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5173",
                                              "https://localhost:5173");
                      });
});

var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);
app.UseExceptionHandler(error =>
{

    error.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/json";
        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

        if (contextFeature != null)
        {
            await context.Response.WriteAsync(new Error
            {
                StatusCode = context.Response.StatusCode,
                Message = contextFeature.Error.Message.Contains("Error:") ? (contextFeature.Error.Message).Replace("Error:", "") : "Internal Server Error. Please Try Again Later.",
                Path = context.Request.Path
            }.ToString());
        }
    });
});



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
