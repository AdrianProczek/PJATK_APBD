using WebApplication.DTO;
using WebApplication.Models;

namespace WebApplication.Services
{
    public interface AnimalService
    {
        public IEnumerable<Animals> GetAnimals(string orderBy);
        public Animals GetAnimalById(int id);
        public int CreateAnimal(Animals animal);
        public int UpdateAnimal(AnimalRepository animal);
        public int DeleteAnimal(int id);
    }

}
