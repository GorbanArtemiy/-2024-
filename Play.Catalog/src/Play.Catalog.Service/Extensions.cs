using Play.Catalog.Service.Dtos;
using Play.Catalog.Service.Entities;

namespace Play.Catalog.Service
{
    public static class Extensions
    {
        public static PetDto AsDto(this Pet pet)
        {
            return new PetDto(pet.Id, pet.Name, pet.Type, pet.Breed, pet.Habitat, pet.Description, pet.Price, pet.AddedDate);
        }
    }
}