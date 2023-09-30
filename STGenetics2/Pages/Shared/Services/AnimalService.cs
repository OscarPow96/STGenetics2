using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using STGenetics.Shared.Models;
using STGenetics2.Pages;

namespace STGenetics.Pages
{
    public class AnimalService : IAnimalService
    {
        private string _filePath = "STGenetics2/Data/animal.json";

        public async Task<List<Animal>> GetAnimalsAsync()
        {
            try
            {
                // Leer el contenido del archivo JSON
                string json = await File.ReadAllTextAsync(_filePath);

                // Verificar si el JSON es nulo
                if (json != null)
                {
                    // Deserializar el JSON a una lista de animales
                    return JsonConvert.DeserializeObject<List<Animal>>(json);
                }
                else
                {
                    Console.WriteLine("El contenido JSON es nulo.");
                    return new List<Animal>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el archivo JSON: " + ex.Message);
                return new List<Animal>();
            }
        }

        public async Task<List<Animal>> GetAnimalsFromJson()
        {
            try
            {
                // Leer el contenido del archivo JSON
                string json = await File.ReadAllTextAsync(_filePath);

                // Verificar si el JSON es nulo
                if (json != null)
                {
                    // Deserializar el JSON a una lista de animales
                    return JsonConvert.DeserializeObject<List<Animal>>(json);
                }
                else
                {
                    Console.WriteLine("El contenido JSON es nulo.");
                    return new List<Animal>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el archivo JSON: " + ex.Message);
                return new List<Animal>();
            }
        }

        public async Task<Animal> GetAnimalByIdAsync(int animalId)
        {
            var animals = await GetAnimalsAsync();
            return animals.FirstOrDefault(a => a.AnimalId == animalId);
        }

        public async Task AddAnimalAsync(Animal animal)
        {
            try
            {
                var animals = await GetAnimalsAsync();

                animal.AnimalId = animals.Any() ? animals.Max(a => a.AnimalId) + 1 : 1;

                animals.Add(animal);

                string json = JsonConvert.SerializeObject(animals, Newtonsoft.Json.Formatting.Indented);

                await File.WriteAllTextAsync(_filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar un animal: " + ex.Message);
            }
        }

        public async Task UpdateAnimalAsync(Animal updatedAnimal)
        {
            try
            {
                var animals = await GetAnimalsAsync();

                Animal existingAnimal = animals.FirstOrDefault(a => a.AnimalId == updatedAnimal.AnimalId);
                if (existingAnimal != null)
                {
                    existingAnimal.Name = updatedAnimal.Name;
                    existingAnimal.Breed = updatedAnimal.Breed;
                    existingAnimal.BirthDate = updatedAnimal.BirthDate;
                    existingAnimal.Sex = updatedAnimal.Sex;
                    existingAnimal.Price = updatedAnimal.Price;
                    existingAnimal.Status = updatedAnimal.Status;
                }

                string json = JsonConvert.SerializeObject(animals, Newtonsoft.Json.Formatting.Indented);

                await File.WriteAllTextAsync(_filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar un animal: " + ex.Message);
            }
        }

        public async Task DeleteAnimalAsync(int animalId)
        {
            try
            {
                var animals = await GetAnimalsAsync();

                animals.RemoveAll(a => a.AnimalId == animalId);

                string json = JsonConvert.SerializeObject(animals, Newtonsoft.Json.Formatting.Indented);

                await File.WriteAllTextAsync(_filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar un animal: " + ex.Message);
            }
        }
    }
}
