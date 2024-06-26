
using StripePaymentTestApi.Interfaces;
using StripePaymentTestApi.Models;
using StripePaymentTestApi.Repositories;
using StripePaymentTestApi.Services;
using StripePaymentTestApi.utils;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// IOptions 
builder.Services.Configure<StripeCredential>(builder.Configuration.GetSection("StripeKey"));


builder.Services.AddScoped<IJsonConfig, JsonConfigRepository>();
builder.Services.AddScoped<ICreditDetails, CreditDetailsRepository>();

builder.Services.AddScoped<UserCreditDetailsService>();
builder.Services.AddSingleton<StripeCardManager>();

//possible object cycle avoiding 
builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
builder.Services.AddCors();

builder.Services.AddResponseCaching();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();    
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
