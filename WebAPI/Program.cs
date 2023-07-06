using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//AOP
//IoC Container -- Inversion of Control --> Autofac, Ninject, CastleWindsor, StructureMap, LightInject, DryInject
//AOP
//Postsharp --> ancak kurumsal ve ücretli altyapi mevcut 

//builder.Services.AddSingleton<IProductService, ProductManager>();
//builder.Services.AddSingleton<IProductDal, EfProductDal>();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(options =>
    options.RegisterModule(new AutofacBusinessModule())
));

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
 