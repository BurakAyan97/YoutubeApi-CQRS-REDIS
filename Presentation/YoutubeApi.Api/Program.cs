using YoutubeApi.Persistance;
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
