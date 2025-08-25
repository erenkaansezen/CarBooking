using Application.Features.CQRS.Handlers.AboutHandlers;
using Application.Interfaces;
using Web.Persistence.Context;
using Web.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddScoped<WebContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandle>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();

builder.Services.AddControllers();

// Swagger servisleri
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // Swagger JSON endpoint
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        // Swagger UI /swagger altında açılır
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
