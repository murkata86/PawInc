namespace PawIcn.Core.Factory
{
    using Interfaces;
    using Models.Animals;

    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string animalType, string animalName, int animalAge, int additionalSpec)
        {
            IAnimal animal = null;

            switch (animalType)
            {
                case "Cat":
                    animal = new Cat(animalName, animalAge, additionalSpec);
                    break;
                case "Dog":
                    animal = new Dog(animalName, animalAge, additionalSpec);
                    break;
            }

            return animal;
        }
    }
}
