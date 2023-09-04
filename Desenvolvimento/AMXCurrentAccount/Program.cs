using AMXCurrentAccount.Adapters.Persistence.Ioc;
using AMXCurrentAccount.Core.Application.Ioc;
using AMXCurrentAccount.Database.CurrentAccount;
using AMXCurrentAccount.Ioc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// start the database
AMXDatabase.startDatabase();

// Services
builder.Services.AddPersistenceRepositories();
builder.Services.AddApplicationServices();
builder.Services.AddPortsPresenters();



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
