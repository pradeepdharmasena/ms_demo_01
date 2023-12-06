using Microsoft.EntityFrameworkCore;
using PlatformService.Repository;
using PlatformService.Services;
using PlatformService.Services.DataSyncing;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPlatformsService, PlatformsService>();
builder.Services.AddHttpClient<ICommandDataClient, CommandDataClient>();
//builder.Services.AddScoped<DbContext, AppDbContext>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("PlatformDb")
    );

var app = builder.Build();



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
