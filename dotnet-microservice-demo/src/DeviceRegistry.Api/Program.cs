using DeviceRegistry.Api.Data;
using DeviceRegistry.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using DeviceRegistry.Api.Contracts;
using DeviceRegistry.Api.Domain;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();

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

app.MapGet("/devices", async (IDeviceRepository repo) =>
{
    var devices = await repo.GetAllAsync();
    return Results.Ok(devices);
})
.WithName("GetDevices")
.WithOpenApi();

app.MapGet("/devices/{id:int}", async (int id, IDeviceRepository repo) =>
{
    var device = await repo.GetByIdAsync(id);

    if (device is null)
        return Results.NotFound(new { message = $"Device with id {id} not found." });

    return Results.Ok(device);
})
.WithName("GetDeviceById")
.WithOpenApi();


app.MapPost("/devices", async (CreateDeviceRequest request, IDeviceRepository repo) =>
{
    // Basic validation (snabb och tydlig)
    if (string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.Type))
        return Results.BadRequest(new { message = "Name and Type are required." });

    var device = new Device
    {
        Name = request.Name.Trim(),
        Type = request.Type.Trim(),
        CreatedAt = DateTime.UtcNow
    };

    await repo.AddAsync(device);

    // Return 201 + location header till resursen
    return Results.Created($"/devices/{device.Id}", device);
})
.WithName("CreateDevice")
.WithOpenApi();

app.MapGet("/health", () => Results.Ok(new { status = "Healthy" }))
    .WithName("Health")
    .WithOpenApi();

app.Run();
