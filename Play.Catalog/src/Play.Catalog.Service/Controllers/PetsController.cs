using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Play.Catalog.Service.Dtos;
using Play.Catalog.Service.Entities;
using Play.Catalog.Service.Repositories;

namespace Play.Catalog.Service.Controllers
{
    [ApiController]
    [Route("pets")]
    public class PetsController : ControllerBase
    {

        private readonly PetsRepository petsRepository = new();

        [HttpGet]
        public async Task<IEnumerable<PetDto>> GetAsync()
        {
            var pets = (await petsRepository.GetAllAsync()).Select(pet => pet.AsDto());
            return pets;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PetDto>> GetByIdAsync(Guid id)
        {
            var pet = await petsRepository.GetAsync(id);
            if (pet == null)
            {
                return NotFound();
            }
            return pet.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<PetDto>> PostAsync(CreatePetDto createPetDto)
        {
            var pet = new Pet
            {
                Name = createPetDto.Name,
                Type = createPetDto.Type,
                Breed = createPetDto.Breed,
                Habitat = createPetDto.Habitat,
                Description = createPetDto.Description,
                Price = createPetDto.Price,
                AddedDate = DateTimeOffset.UtcNow
            };
            await petsRepository.CreateAsync(pet);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = pet.Id }, pet);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, UpdatePetDto updatePetDto)
        {
            var existingPet = await petsRepository.GetAsync(id);
            if (existingPet == null)
            {
                return NotFound();
            }

            existingPet.Name = updatePetDto.Name;
            existingPet.Type = updatePetDto.Type;
            existingPet.Breed = updatePetDto.Breed;
            existingPet.Habitat = updatePetDto.Habitat;
            existingPet.Description = updatePetDto.Description;
            existingPet.Price = updatePetDto.Price;

            await petsRepository.UpdateAsync(existingPet);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> PurchaseAsync(Guid id)
        {
            var pet = await petsRepository.GetAsync(id);
            if (pet == null)
            {
                return NotFound();
            }
            await petsRepository.RemoveAsync(pet.Id);
            return NoContent();
        }
    }
}