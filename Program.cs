using gameStore.API.controller;
using gameStore.API.DatabaseConnection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//This section below is for connection string 
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<GameStoreDbContext>(options => options.UseNpgsql(connectionString));
            

app.MapGameController();

// app.MigrateDb();

app.Run();
