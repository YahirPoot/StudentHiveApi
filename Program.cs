using StudentHive.Domain.Entities;
using StudentHive.Services.Features.RentalHouses;
using StudentHive.Services.Features.Users;
using StudentHiveApi.Services.Features.PswdHasher;
using StudentHive.Services.Mappings;
using StudentHive.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;

//*Add services container services
//TODO: Agregar mis repositorios
builder.Services.AddScoped<RentalHouseService>(); //
builder.Services.AddTransient<RentalHouseRepository>();
builder.Services.AddScoped<UsersService>(); // 
builder.Services.AddTransient<UserRepository>(); 

// Administrador 
builder.Services.AddScoped<AdministradorService>();
builder.Services.AddTransient<AdministradorRepository>();

builder.Services.AddScoped<PasswordHasher>(); 


builder.Services.AddControllers(); //*<--- Controller services added 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new() { Title = "StudentHive", Version = "v1" });

    s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
    });

    s.AddSecurityRequirement(new OpenApiSecurityRequirement{
        {
            new OpenApiSecurityScheme{
                Reference = new OpenApiReference{
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Usuario", policy => policy.RequireClaim(ClaimTypes.Role, "Usuario"));
    options.AddPolicy("Administrador", policy => policy.RequireClaim(ClaimTypes.Role, "Administrador"));
});

builder.Services.AddDbContext<StudentHiveDbContext>(
    options => {
        options.UseSqlServer(Configuration.GetConnectionString("gemDevelopment"));
    }
);

var cloudinarySettings = builder.Configuration.GetSection("Cloudinary");
Account account = new Account(
    cloudinarySettings["CloudName"],
    cloudinarySettings["ApiKey"],
    cloudinarySettings["ApiSecret"]
);
Cloudinary cloudinary = new Cloudinary(account);

builder.Services.AddSingleton(cloudinary);
builder.Services.AddScoped<ImageUploadService>();




builder.Services.AddAutoMapper(typeof(ResponseMappingProfile).Assembly);
builder.Services.AddAutoMapper(typeof(RequestCreateMappingProfile).Assembly);
builder.Services.AddAutoMapper(typeof(UpdateMappingProfile).Assembly);


var app = builder.Build();

// Configure Swagger for all environments
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
