using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using STGenetics.Shared.Models;

namespace STGenetics.Shared.Services
{
    public class AnimalService : IAnimalService
    {
        // Simula una base de datos ficticia
        private static List<Animal> _animals = new List<Animal>();

        public Task<List<Animal>> GetAnimalsAsync()
        {
            return Task.FromResult(_animals);
        }

        public Task<Animal> GetAnimalByIdAsync(int animalId)
        {
            return Task.FromResult(_animals.FirstOrDefault(a => a.AnimalId == animalId));
        }

        public Task AddAnimalAsync(Animal animal)
        {
            animal.AnimalId = _animals.Any() ? _animals.Max(a => a.AnimalId) + 1 : 1;
            _animals.Add(animal);
            return Task.CompletedTask;
        }

        public Task UpdateAnimalAsync(Animal animal)
        {
            var existingAnimal = _animals.FirstOrDefault(a => a.AnimalId == animal.AnimalId);
            if (existingAnimal != null)
            {
                existingAnimal.Name = animal.Name;
                existingAnimal.Breed = animal.Breed;
                existingAnimal.BirthDate = animal.BirthDate;
                existingAnimal.Sex = animal.Sex;
                existingAnimal.Price = animal.Price;
                existingAnimal.Status = animal.Status;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAnimalAsync(int animalId)
        {
            _animals.RemoveAll(a => a.AnimalId == animalId);
            return Task.CompletedTask;
        }
    }
}
