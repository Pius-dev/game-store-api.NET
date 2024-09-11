using System.ComponentModel.DataAnnotations;

namespace gameStore.API.Dtos
{
    public record CreateGameDto (
        [Required] string Name,
        [Required] string Genre,
        [Required] decimal Price, 
        [Required] DateOnly ReleaseDate);
}