using Gyms.API.Data;
using Gyms.API.Repositories;
using Gyms.API.Repositories.Interfaces;
using Gyms.API.Services;
using Gyms.API.Services.Validators;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLAuth"),
    x => x.UseDateOnlyTimeOnly())
    );

builder.Services.AddScoped<IClubsRepository, ClubsRepository>();
builder.Services.AddScoped<IOpeningHoursRepository, OpeningHoursRepository>();
builder.Services.AddScoped<ICoachesRepository, CoachesRepository>();
builder.Services.AddScoped<IEventsRepository, EventsRepository>();
builder.Services.AddScoped<IReservationsRepository, ReservationsRepository>();

builder.Services.AddScoped<CoachesService>();
builder.Services.AddScoped<ClubsService>();
builder.Services.AddScoped<EventsService>();
builder.Services.AddScoped<ReservationsService>();

builder.Services.AddScoped<ReservationsValidator>();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

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
