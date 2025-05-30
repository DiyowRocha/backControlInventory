using backControlInventory.Application;
using backControlInventory.Application.Mapping;
using backControlInventory.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Support to MVC Controller
builder.Services.AddControllers();
// Support to Swagger
builder.Services.AddEndpointsApiExplorer();
// Create Documentation for Swagger
builder.Services.AddSwaggerGen();
// Mapper
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
// Registration Services
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddServices();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyOrigin()
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

app.UseHttpsRedirection();
app.MapControllers();
app.Run();