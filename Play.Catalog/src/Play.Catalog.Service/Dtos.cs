using System;
using System.ComponentModel.DataAnnotations;

namespace Play.Catalog.Service.Dtos
{
    public record PetDto(Guid Id, string Name, string Type, string Breed, string Habitat, string Description, decimal Price, DateTimeOffset AddedDate);

    public record CreatePetDto([Required] string Name, string Type, string Breed, string Habitat, string Description, [Range(0, 100000)] decimal Price);

    public record UpdatePetDto([Required] string Name, string Type, string Breed, string Habitat, string Description, [Range(0, 100000)] decimal Price);
}