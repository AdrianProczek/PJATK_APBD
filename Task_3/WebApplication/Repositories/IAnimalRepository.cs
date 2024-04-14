using WebApplication.Models;

namespace WebApplication.Repositories
{
    public class IAnimalRepository
    {
        IEnumerable<Animal> GetAnimals(string orderBy);
        IAnimalRepository GetAnimalById(int id);

        public int CreateAnimal(Animal animal);

        public int DeleteAnimal(int id)

        public int UpdateAnimal(Animal animal);
    }
}
