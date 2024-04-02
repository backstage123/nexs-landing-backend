using Api.Middlewares;
using Application.Services;
using Domain.Entities;
using Domain.IRepositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Rewrite;
using Persistence;
using Persistence.Repositories;
using System.Net;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

//Must be uncommented for deployments
//builder.WebHost.ConfigureKestrel((context, options) =>
//{
//    options.Listen(IPAddress.Loopback, 5000); // Set your desired port here
//});

var configuration = builder.Configuration;


// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.SetIsOriginAllowed(_ => true)
                                //.WithOrigins("http://localhost:4200");
                                //.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .AllowCredentials();
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddLogging();

builder.Services.AddScoped<UserServices>();

builder.Services.AddScoped<NoticeService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IRepository<Notice, int>, NoticeRepository>();

builder.Services.AddDbContext<ApplicationDbContext>();

builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();
//builder.Host.UseSystemd().ConfigureWebHostDefaults(webBuilder =>
//{
//    webBuilder.UseUrls(new[] { "http://localhost:5000" });
//});

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var app = builder.Build();
//app.Listen("http://localhost:5000");
app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else if (app.Environment.IsProduction())
{
    var option = new RewriteOptions();
    option.AddRedirect("^$", "swagger/index.html");
    app.UseRewriter(option);

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseStaticFiles();

//app.UseRouting();

//app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
