using Microsoft.EntityFrameworkCore;
using Tengil.Service;
using tngcmd.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLogging();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<TengilService>();
builder.Services.AddCors(options => {
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
builder.Services.AddAutoMapper(typeof(Tengil.API.AutoMapperProfile));
string connectionString = builder.Configuration.GetConnectionString("TengilDBConnection") ?? throw new Exception("Missing connection string TengilDBConnection");
Console.WriteLine($"Connection to {connectionString}");
builder.Services.AddDbContext<TengilContext>(opt => opt.UseMySQL(connectionString));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
