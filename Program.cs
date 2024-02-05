using StudentHive.Domain.Entities;
using StudentHive.Infrastructure.Data;
// using StudentHive.Infrastructure.Repositories;
using StudentHive.Services.Features.RentalHouses;
using StudentHive.Services.Features.Users;
using StudentHive.Services.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StudentHive.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;

//*Add services container services
//TODO: Agregar mis repositorios
builder.Services.AddScoped<RentalHouseService>(); //
builder.Services.AddTransient<RentalHouseRepository>();
builder.Services.AddScoped<UsersService>(); // 
builder.Services.AddTransient<UserRepository>(); 

// builder.Services.AddSingleton<RentalHouseService>(); //*<--- Singleton services added 
// builder.Services.AddSingleton<UsersService>(); //*<--- Singleton services added 

builder.Services.AddControllers(); //*<--- Controller services added 
builder.Services.AddDbContext<StudentHiveDbContext>(
    options => {
        options.UseSqlServer(Configuration.GetConnectionString("gemDevelopment"));
    }
);
//*Add services to the container.   

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//*Using mappings services
builder.Services.AddAutoMapper(typeof(ResponseMappingProfile).Assembly);
builder.Services.AddAutoMapper(typeof(RequestCreateMappingProfile).Assembly);
builder.Services.AddAutoMapper(typeof(UpdateMappingProfile).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure Swagger for all environments
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
