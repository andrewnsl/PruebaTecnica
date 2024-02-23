using PruebaTecnica.Models.Entities;
using PruebaTecnica.Helpers.Extensions;
using System.Reflection;
using PruebaTecnica.Helpers.AutoMapping;
using PruebaTecnica.Helpers.LoggerManager;
using PruebaTecnica.Services.Interfaces;
using PruebaTecnica.Services;
using PruebaTecnica.DataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfiguration Configuration = builder.Configuration;

builder.Services.AddDbGenericContext<PruebaTecnicaContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
builder.Services.AddSwaggerCustom(xmlPath, "PruebaTecnica");

builder.Services.AddTransient<ILog, Log>();
builder.Services.AddTransient(typeof(IDataRepository<>), typeof(DataRepository<>));
builder.Services.AddTransient<IGenericService, GenericService>();
builder.Services.AddTransient<IIncomeService, IncomeService>();

builder.Services.AddAutoMapper(c => c.AddProfile<AutoMappingHelper>(), typeof(Program).Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger(c => c.SerializeAsV2 = false);
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.Json", "NatilleraApp v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
