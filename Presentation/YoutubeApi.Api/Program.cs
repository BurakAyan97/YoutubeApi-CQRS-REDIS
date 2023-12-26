using YoutubeApi.Persistance;
using YoutubeApi.Application;
using YoutubeApi.Infrastructure;
using YoutubeApi.Mapper;
using YoutubeApi.Application.Exceptions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var env = builder.Environment;

builder.Configuration
    .SetBasePath(env.ContentRootPath) //CAnlıya alınca root değişecek. Bir nevi generic olsun diye yapılan bir method
      .AddJsonFile("appsettings.json", optional: false)
      .AddJsonFile($"appsettings. {env.EnvironmentName}.json", optional: true);

builder.Services.AddPersistence(builder.Configuration);//jsonfile'dan aşağıda olmalı çünkü hangi enviromentda olduğumuzu bilip ona göre connstr seçsin. 

builder.Services.AddApplication();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddCustomMapper();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "YoutubeApi", Version = "v1", Description = "YoutubeApi swagger client." });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "'Bearer' yazıp boşluk bıraktıktan sonra Token'ı girebilirsiniz",

    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference=new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.ConfigureExceptionHandlingMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
