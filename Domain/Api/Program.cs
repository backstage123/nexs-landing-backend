using Api.Middlewares;
using Application.Services;
using Domain.Entities;
using Domain.IRepositories;
using Persistence;
using Persistence.Repositories;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {      
                          policy.SetIsOriginAllowed(_ => true)
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

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
