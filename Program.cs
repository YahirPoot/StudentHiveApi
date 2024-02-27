using StudentHive.Domain.Entities;
using StudentHive.Services.Features.Users;
using StudentHiveApi.Services.Features.PswdHasher;
using StudentHive.Services.Mappings;
using Microsoft.EntityFrameworkCore;
using StudentHive.Infrastructure.Repositories;
using System.Security.Claims;


var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;

//*Add services container services
//TODO: Agregar mis repositorios

builder.Services.AddScoped<UsersService>();  
builder.Services.AddTransient<UserRepository>(); 

builder.Services.AddScoped<PasswordHasher>(); 

// builder.Services.AddSingleton<RentalHouseService>(); //*<--- Singleton services added 
// builder.Services.AddSingleton<UsersService>(); //*<--- Singleton services added 

builder.Services.AddControllers(); //*<--- Controller services added 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("User", policy => policy.RequireClaim(ClaimTypes.Role, "Usuario"));
    options.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Role, "Administrador"));
});

builder.Services.AddDbContext<StudentHiveDbContext>(
    options => {
        options.UseSqlServer(Configuration.GetConnectionString("gemDevelopment"));
    }
);
//*Add services to the container.   


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

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
