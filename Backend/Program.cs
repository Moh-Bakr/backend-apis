global using Backend.Models;
using Backend.Data;
using Backend.Services.Clients;
using Backend.Services.Samples;

var policyName = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

builder.Services.AddAutoMapper(typeof(Program).Assembly); 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddTransient<IClientService, ClientService>();
builder.Services.AddTransient<ISampleService, SampleService>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors(policyName);
app.UseAuthorization();

app.MapControllers();

app.Run();