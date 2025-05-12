using FluentValidation;
using FluentValidation.AspNetCore;
using MyFavoriteMusic.Api.Configurations;
using MyFavoriteMusic.Api.Middlewares;
using MyFavoriteMusic.Api.Validators.Album;
using MyFavoriteMusic.Api.Validators.Artist;
using MyFavoriteMusic.Application.Interfaces;
using MyFavoriteMusic.Application.Services;
using MyFavoriteMusic.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddApiConfiguration();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(typeof(CreateAlbumRequestValidator).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(UpdateAlbumRequestValidator).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(UpdateArtistRequestValidator).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(CreateArtistRequestValidator).Assembly);
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters(); 
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionMiddleware();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

