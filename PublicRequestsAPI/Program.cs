using Microsoft.EntityFrameworkCore;
using PublicRequestsAPI.Application.Implementation;
using PublicRequestsAPI.Application.Interfaces;
using PublicRequestsAPI.Application.Mappers;
using PublicRequestsAPI.Domain.Interfaces;
using PublicRequestsAPI.Infrastructure.Database;
using PublicRequestsAPI.Infrastructure.Implementations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RequestsDbContext>(opt =>
    opt.UseInMemoryDatabase("RequestsDb"));
builder.Services.AddAutoMapper(typeof(RequestMappingProfile));
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.MapControllers();
app.Run();
