using DaceloApi.Handlers;
using DaceloApi.SQL;

//CSL dependency injection
CSL.DependencyInjection.NpgsqlConnectionConstructor = (x) => new Npgsql.NpgsqlConnection(x);
CSL.DependencyInjection.NpgsqlConnectionStringConstructor = () => new Npgsql.NpgsqlConnectionStringBuilder();
CSL.DependencyInjection.SslModeConverter = (x) => (Npgsql.SslMode)x;

await SQLHandler.Init();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>  
{  
    options.AddDefaultPolicy(  
        policy =>  
        {  
            policy.AllowAnyOrigin();  //set the allowed origin  
        });  
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

UptimeHandler.StartTimer();