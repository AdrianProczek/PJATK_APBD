using WebApplication.Models;

namespace WebApplication.Services
{
    public interface IAnimalService
    {
        IEnumerable<Animals> GetAnimals(string orderBy);
        int CreateAnimal(Animals animal);
        int UpdateAnimal(Animals animal);
        int DeleteAnimal(int idAnimal);
    }
}
