using NotificationsAPI.CORS;
using NotificationsAPI.CORS.NotifyUser;
using NotificationsAPI.Infrastructure.Services;
using NotificationsAPI.Mediator;
using SendGrid.Extensions.DependencyInjection;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var sendGridApiKey = builder.Configuration.GetSection("SENDGRID_API_KEY").Value;

builder.Services.AddScoped<INotificationFactoryService, NotificationFactoryService>();

builder.Services.AddScoped<NotifyUserCommandHandler>();

builder.Services.AddScoped<ICommandHandler<NotifyUserCommand, Task>, NotifyUserCommandHandlerDecorator>();

builder.Services.AddScoped<IMediator, Mediator>();

builder.Services.AddSendGrid(options => {
    options.ApiKey = sendGridApiKey;
});

builder.Host.ConfigureAppConfiguration((hostingContext, config) => {
    Serilog.Log.Logger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .CreateLogger();
}).UseSerilog();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

