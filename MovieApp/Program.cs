using MovieApp.Data;
using MovieApp.Data.Interfaces;
using MovieApp.Domain.Commands;
using MovieApp.Domain.Commands.Interfaces;
using MovieApp.Domain.Commands.Movies;
using MovieApp.Domain.Models;
using MovieApp.Domain.Queries;
using MovieApp.Domain.Queries.Interfaces;
using MovieApp.Domain.Queries.Movies;
using MovieApp.Domain.Setup.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IMovieRespository, MovieRepository>();

builder.Services.AddScoped<ICommand, AddMovieCommand>();
builder.Services.AddScoped<ICommand, DeleteMovieCommand>();
builder.Services.AddScoped<ICommand, UpdateMovieCommand>();
builder.Services.AddScoped<ICommandHandler<AddMovieCommand, int>, AddMovieHandler>();
builder.Services.AddScoped<ICommandHandler<DeleteMovieCommand>, DeleteMovieHandler>();
builder.Services.AddScoped<ICommandHandler<UpdateMovieCommand>, UpdateMovieHandler>();
builder.Services.AddScoped<ICommandDispatcher, CommandDispatcher>();

builder.Services.AddScoped<IQuery, GetMovieQuery>();
builder.Services.AddScoped<IQuery, GetMultipleMoviesQuery>();
builder.Services.AddScoped<IQueryHandler, GetMovieHandler>();
builder.Services.AddScoped<IQueryHandler<GetMultipleMoviesQuery, Movie>, GetMultipleMoviesHandler>();
builder.Services.AddScoped<IQueryHandler<GetMovieQuery, Movie>, GetMovieHandler>();
builder.Services.AddScoped<IQueryDispatcher, QueryDispatcher>();


builder.Services.AddAutoMapper(typeof(DomainProfile));

builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
