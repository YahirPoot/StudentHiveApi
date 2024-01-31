using StudentHive.Services.Features.RentalHouses;

var builder = WebApplication.CreateBuilder(args);

//container services

builder.Services.AddScoped<RentalHouseService>(); //<--- services added 

builder.Services.AddSingleton<RentalHouseService>(); //<--- services added 

builder.Services.AddControllers(); //<--- services added 

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
