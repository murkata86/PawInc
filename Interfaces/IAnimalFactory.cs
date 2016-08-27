namespace PawIcn.Interfaces
{
    public interface IAnimalFactory
    {
        IAnimal CreateAnimal(string animalType, string animalName, int animalAge, int additionalSpec);
    }
}
