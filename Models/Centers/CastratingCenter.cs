namespace PawIcn.Models.Centers
{
    using System.Collections.Generic;
    using Interfaces;
    public class CastratingCenter : Center, ICastratingCenter
    {
        private List<IAnimal> castratedAnimals;
        private List<KeyValuePair<IAdoptionCenter, IAnimal>> animalsForCastration;

        public CastratingCenter(string name) : 
            base(name)
        {
            this.castratedAnimals = new List<IAnimal>();
            this.animalsForCastration = new List<KeyValuePair<IAdoptionCenter, IAnimal>>();
        }

        public void AddAnimalsForCastration(IAdoptionCenter adoptionCenter, List<IAnimal> animals)
        {
            foreach (var animal in animals)
            {
                this.animalsForCastration.Add(new KeyValuePair<IAdoptionCenter, IAnimal>(adoptionCenter, animal));
            }
        }

        public void CastrateAnimals()
        {
            for (int i = 0; i < this.animalsForCastration.Count; i++)
            {
                var animal = this.animalsForCastration[i];

                animal.Value.CastratedStatus = true;

                this.castratedAnimals.Add(animal.Value);

                animal.Key.AcceptCastratedAnimal(animal.Value);
            }

            this.animalsForCastration.Clear();
        }

        public int CastratedAnimalsCount()
        {
            return this.castratedAnimals.Count;
        }

        public IReadOnlyCollection<KeyValuePair<IAdoptionCenter, IAnimal>> AnimalsAwaitingCastrating()
        {
            return this.animalsForCastration;
        }

        public IReadOnlyCollection<IAnimal> CastratedAnimals()
        {
            return this.castratedAnimals;
        } 
    }
}
