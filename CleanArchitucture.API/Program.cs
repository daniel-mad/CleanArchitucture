using CleanArchitucture.Infrastructure;
using log4net.Config;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//Configure Log4net.
XmlConfigurator.Configure(new FileInfo("log4net.config"));

//Injecting services -> defined under CleanArch.Infrastructure project. 
builder.Services.RegisterServices();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.AddSecurityDefinition("Basic", new OpenApiSecurityScheme
    {
        Description = "Basic Api Key",
        Name = "Autorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Basic"
    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Basic"
                },
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
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
