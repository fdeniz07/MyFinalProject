using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//IoC Container -- Inversion of Control --> Autofac, Ninject, CastleWindsor, StructureMap, LightInject, DryInject

//Business Service'leri --> Daha sonra kendi katmaninda ServiceRegistration class'inda toplanip buraya referans edilecekler.
builder.Services.AddSingleton<IProductService, ProductManager>();

//DataAccess Interface'leri --> Daha sonra kendi katmaninda ServiceRegistration class'inda toplanip buraya referans edilecekler.
builder.Services.AddSingleton<IProductDal, EfProductDal>();


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