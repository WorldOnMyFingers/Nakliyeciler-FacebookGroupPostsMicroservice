using System.Reflection.Metadata;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using FacebookGroupPostsMicroservice.MongoDb;
using FacebookGroupPostsMicroservice.Services;
using Infrastructure;
using Infrastructure.Configurations;
using Infrastructure.Contexts;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
});
// Add services to the container.
builder.Services.Configure<GroupPostConfiguration>(
                options =>
                {
                    options.ConnectionString = builder.Configuration.GetSection("MongoDB:ConnectionString").Value;
                    options.Database = builder.Configuration.GetSection("MongoDB:Database").Value;
                }
            );
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Register services directly with Autofac here. Don't
// call builder.Populate(), that happens in AutofacServiceProviderFactory.
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new DomainModule()));
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new MediatorModule()));

builder.Services.AddSingleton<IGroupPostContext, GroupPostContext>();
builder.Services.AddSingleton<DomainModule>();
builder.Services.AddSingleton<MediatorModule>();

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

