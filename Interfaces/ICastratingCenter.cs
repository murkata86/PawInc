namespace PawIcn.Interfaces
{
    using System.Collections.Generic;

    public interface ICastratingCenter : ICenter
    {
        void AddAnimalsForCastration(IAdoptionCenter adoptionCenter, List<IAnimal> animals);
        void CastrateAnimals();
        int CastratedAnimalsCount();
        IReadOnlyCollection<KeyValuePair<IAdoptionCenter, IAnimal>> AnimalsAwaitingCastrating();
        IReadOnlyCollection<IAnimal> CastratedAnimals();
    }
}
