using MyExpenditure.AutoMapperProfiles;
//using MyExpenditure.Data;
using MyExpenditure.Interfaces;
using MyExpenditure.Repositories;
using Microsoft.EntityFrameworkCore;
using MyExpenditure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the database context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// Register the repository with Dependency Injection
builder.Services.AddScoped<IExpenditureRepository, ExpenditureRepository>();

// Add CORS policy
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowLocalhost3001",
//        policy => policy
//            .WithOrigins("http://localhost:3001")
//            .AllowAnyHeader()
//            .AllowAnyMethod());
//});
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseCors("AllowLocalhost3001"); // <-- Add this line

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();