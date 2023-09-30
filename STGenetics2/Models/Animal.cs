using System;

namespace STGenetics.Shared.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public DateTime BirthDate { get; set; }
        public string Sex { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public bool Selected { get; set; }

        // Constructor por defecto
        public Animal()
        {
            // Puedes inicializar propiedades con valores predeterminados si lo deseas
            AnimalId = 0;
            Name = string.Empty;
            Breed = string.Empty;
            BirthDate = DateTime.MinValue;
            Sex = string.Empty;
            Price = 0.0m;
            Status = string.Empty;
        }

        // Constructor para inicialización
        public Animal(int animalId, string name, string breed, DateTime birthDate, string sex, decimal price, string status)
        {
            AnimalId = animalId;
            Name = name;
            Breed = breed;
            BirthDate = birthDate;
            Sex = sex;
            Price = price;
            Status = status;
        }
    }
}
