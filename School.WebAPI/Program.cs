using School.WebAPI.Application;
using School.WebAPI.Application.Interfaces;
using School.WebAPI.Application.Services;
using School.WebAPI.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("SchoolKZL");

builder.Services.AddScoped<DatabaseService>(provider => new DatabaseService(connectionString));
builder.Services.AddAutoMapper(typeof(SchoolMappingProfile));
builder.Services.AddScoped<ITeacherServices, TeacherServices>();
builder.Services.AddScoped<ISchoolClassesService , SchoolClassesService>();

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
