﻿using WebApplication.Models;

namespace WebApplication.Repositories
{
    public interface IAnimalRepository
    {
        IEnumerable<Animals> GetAnimals(string orderBy);
        Animals GetAnimal(int id);
        int CreateAnimal(Animals animal);
        int UpdateAnimal(Animals animal);
        int DeleteAnimal(int id);
    }
}
