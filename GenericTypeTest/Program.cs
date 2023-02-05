using GenericTypeTest;
using GenericTypeTest.Abstract;
using GenericTypeTest.Concrete;
using GenericTypeTest.ControllerFactory;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Soyut ve somut repository sýnýflarýmýz scope ile IoC üzerinde ekliyoruz.
// Burada generic tip geleceði için typeof ile alýyor, tip kýsmý boþ býrakýyoruz...
builder.Services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>)); 
//Db Context IoC eklemesi...
builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MssqlContext")));


//Mvc Servisini ekliyoruz...
var mvcBuilder = builder.Services.AddMvc();
//Eklediðimiz Mvc servisine ait option özelliklerine, oluþturduðumuz Attribute sýnýfýmý veriyoruz...
mvcBuilder.AddMvcOptions(o => o.Conventions.Add(new GenericRestControllerNameConvention()));
//Eklediðimiz Mvc sýnýfýnýn ConfigureApplicationPartManager içerisine Feature provider ile aldýðýmýz entity modellerinin eklemesini yapýyoruz...
mvcBuilder.ConfigureApplicationPartManager(c =>
{
    c.FeatureProviders.Add(new GenericRestControllerFeatureProvider());
});
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
