
using gameStore.API.Dtos;
using Microsoft.VisualBasic;

namespace gameStore.API.controller
{
    public static class GamesController
    {
       const string GetGameEndpointName = "GetGame";

        private static readonly List<GameDto> games = [
        new GameDto(1, "FIFA 24", "Sports", 59.99m, new DateOnly(2024, 9, 6)),
        new GameDto(2, "Call of Duty: Modern Warfare", "Shooter", 69.99m, new DateOnly(2023, 11, 12)),
        new GameDto(3, "Minecraft", "Sandbox", 29.99m, new DateOnly(2011, 11, 18)),
        new GameDto(4, "The Legend of Zelda: Breath of the Wild", "Adventure", 59.99m, new DateOnly(2017, 3, 3)),
        new GameDto(5, "Elden Ring", "Action RPG", 59.99m, new DateOnly(2022, 2, 25))];

    public static RouteGroupBuilder MapGameController(this WebApplication app){

        var group = app.MapGroup("games")
                            .WithParameterValidation();

        // GET ALL
group.MapGet("/", () => games);

// GET by ID
group.MapGet("/{id}", (int id) => 
    {
    GameDto? game = games.Find(game => game.Id == id);
    return game is null ? Results.NotFound() : Results.Ok(game);
    })
.WithName(GetGameEndpointName);

// POST /games
group.MapPost("/", (CreateGameDto newGame) => {
    GameDto game = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate);
    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndpointName, new {id = game.Id}, game);
});

// PUT/UPDATE 
group.MapPut("/{id}", (int id, UpdateGameDto updateGame) => {
    var index = games.FindIndex(game => game.Id == id);
    games[index] = new GameDto(id, updateGame.Name,updateGame.Genre, updateGame.Price, updateGame.ReleaseDate);

    return Results.NoContent();
});

// DELETE /games/1
group.MapDelete("/{id}", (int id) =>
{
    games.RemoveAll(game => game.Id == id);
    return Results.NoContent();
});

        return group;
    }

    }
}