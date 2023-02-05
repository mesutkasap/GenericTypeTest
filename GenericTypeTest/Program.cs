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
//Soyut ve somut repository s�n�flar�m�z scope ile IoC �zerinde ekliyoruz.
// Burada generic tip gelece�i i�in typeof ile al�yor, tip k�sm� bo� b�rak�yoruz...
builder.Services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>)); 
//Db Context IoC eklemesi...
builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MssqlContext")));


//Mvc Servisini ekliyoruz...
var mvcBuilder = builder.Services.AddMvc();
//Ekledi�imiz Mvc servisine ait option �zelliklerine, olu�turdu�umuz Attribute s�n�f�m� veriyoruz...
mvcBuilder.AddMvcOptions(o => o.Conventions.Add(new GenericRestControllerNameConvention()));
//Ekledi�imiz Mvc s�n�f�n�n ConfigureApplicationPartManager i�erisine Feature provider ile ald���m�z entity modellerinin eklemesini yap�yoruz...
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
