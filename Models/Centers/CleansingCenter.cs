namespace PawIcn.Models.Centers
{
    using System.Collections.Generic;
    using Interfaces;

    public class CleansingCenter : Center, ICleansingCenter
    {
        private List<KeyValuePair<IAdoptionCenter, IAnimal>> animalsForCleansing;
        private List<IAnimal> cleansedAnimals; 

        public CleansingCenter(string name) : 
            base(name)
        {
            this.animalsForCleansing = new List<KeyValuePair<IAdoptionCenter, IAnimal>>();
            this.cleansedAnimals = new List<IAnimal>();
        }

        public void AddAnimals(IAdoptionCenter adoptionCenterName, List<IAnimal> animals)
        {
            foreach (var animal in animals)
            {
                this.animalsForCleansing.Add(new KeyValuePair<IAdoptionCenter, IAnimal>(adoptionCenterName, animal));
            }
        }

        public void CleanseAnimals()
        {
            for (int i = 0; i < this.animalsForCleansing.Count; i++)
            {
                var animal = this.animalsForCleansing[i];

                animal.Value.CleansedStatus = true;

                this.cleansedAnimals.Add(animal.Value);

                animal.Key.AcceptCleansedAnimal(animal.Value);
            }
            
            this.animalsForCleansing.Clear();
        }

        public int CleansedAnimals
        {
            get { return this.cleansedAnimals.Count; }
        }

        public IReadOnlyCollection<KeyValuePair<IAdoptionCenter, IAnimal>> AnimalsWaitngForCleansing()
        {
            return this.animalsForCleansing;
        }

        public IReadOnlyCollection<IAnimal> GetCleansedAnimals()
        {
            return this.cleansedAnimals;
        } 
    }
}