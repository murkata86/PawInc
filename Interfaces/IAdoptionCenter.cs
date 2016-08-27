namespace PawIcn.Interfaces
{
    using System.Collections.Generic;

    public interface IAdoptionCenter : ICenter
    {
        void AddAnimal(IAnimal animal);
        void AcceptCleansedAnimal(IAnimal cleansedAnimal);
        void AcceptCastratedAnimal(IAnimal castratedAnimal);
        void SendAnimalsForCleansing(ICleansingCenter cleansingCenter);
        void SendAnimalsForCastrating(ICastratingCenter castratingCenter);
        IReadOnlyCollection<IAnimal> AnimalsForAdoption();
        IReadOnlyCollection<IAnimal> GetAdoptedAnimals();
        void AdoptAnimals();
        int AdoptedAnimalsCount { get; }
    }
}
