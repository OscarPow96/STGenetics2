using System.Collections.Generic;
using System.Threading.Tasks;
using STGenetics.Shared.Models;

namespace STGenetics.Shared.Services
{
    public interface IAnimalService
    {
        Task<List<Animal>> GetAnimalsAsync();
        Task<Animal> GetAnimalByIdAsync(int animalId);
        Task AddAnimalAsync(Animal animal);
        Task UpdateAnimalAsync(Animal animal);
        Task DeleteAnimalAsync(int animalId);
    }
}
