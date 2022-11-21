using UDPTracker.Extensions;
using UDPTracker.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

//Extension method for registering all the services
builder.RegisterServices();

builder.ConfigureDbContext();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var udpServerService = app.Services.CreateScope()
                                   .ServiceProvider.GetRequiredService<IUDPServerService>();

await udpServerService.StartListenerAsync();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();