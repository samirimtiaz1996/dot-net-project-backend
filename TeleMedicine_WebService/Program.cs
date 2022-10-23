using CommandHandler;
using Commands.UAM;
using Contract;
using Domains.DBModels;
using Domains.Entities;
using Domains.Mappers;
using Infrastructure.Core.Managers;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MongoDbGenericRepository;
using TeleMedicine_WebService.Pipeline;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(CreateUserCommand).Assembly, typeof(CreateUserCommandHandler).Assembly);
builder.Services.AddAutoMapper(typeof(ToiletLocationMappingProfile));

var config = builder.Configuration;
var mongoDbContext = new MongoDbContext(config.GetSection("Mongosettings:Connection").Value, config.GetSection("Mongosettings:DatabaseName").Value);

builder.Services.AddIdentity<TelemedicineAppUser, TelemedicineAppRole>()
  .AddMongoDbStores<IMongoDbContext>(mongoDbContext)
  .AddDefaultTokenProviders();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
builder.Services.AddTransient<IUserManagerServices, UserManagerServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   // app.UseSwagger();
   // app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

