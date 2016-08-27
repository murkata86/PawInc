namespace PawIcn.Interfaces
{
    using System.Collections.Generic;

    public interface ICleansingCenter : ICenter
    {
        void AddAnimals(IAdoptionCenter adoptionCenterName, List<IAnimal> animals);
        IReadOnlyCollection<KeyValuePair<IAdoptionCenter, IAnimal>> AnimalsWaitngForCleansing();
        IReadOnlyCollection<IAnimal> GetCleansedAnimals();
        int CleansedAnimals { get; }
        void CleanseAnimals();
    }
}
