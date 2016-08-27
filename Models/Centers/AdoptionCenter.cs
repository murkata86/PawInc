namespace PawIcn.Models.Centers
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    public class AdoptionCenter : Center, IAdoptionCenter
    {
        private List<IAnimal> adoptedAnimals;
        private List<IAnimal> storedAnimals; 
        public AdoptionCenter(string name) : 
            base(name)
        {
            this.adoptedAnimals = new List<IAnimal>();
            this.storedAnimals = new List<IAnimal>();
        }

        public void SendAnimalsForCleansing(ICleansingCenter cleansingCenter)
        {
            var animalsForCleansing = this.storedAnimals.Where(a => a.CleansedStatus == false).ToList();

            cleansingCenter.AddAnimals(this, animalsForCleansing);

            this.storedAnimals.RemoveAll(a => a.CleansedStatus == false);
        }

        public void SendAnimalsForCastrating(ICastratingCenter castratingCenter)
        {
            var animalsForCastrating = this.storedAnimals.Where(c => c.CastratedStatus == false).ToList();

            castratingCenter.AddAnimalsForCastration(this, animalsForCastrating);

            this.storedAnimals.RemoveAll(a => a.CastratedStatus == false);
        }

        public void AddAnimal(IAnimal animal)
        {
            this.storedAnimals.Add(animal);
        }

        public void AcceptCleansedAnimal(IAnimal cleansedAnimal)
        {
            this.storedAnimals.Add(cleansedAnimal);
        }

        public void AcceptCastratedAnimal(IAnimal castratedAnimal)
        {
            this.storedAnimals.Add(castratedAnimal);
        }

        public IReadOnlyCollection<IAnimal> AnimalsForAdoption()
        {
            var animalsForAdoption = this.storedAnimals.Where(a => a.CastratedStatus == true || a.CleansedStatus == true).ToList();

            return animalsForAdoption;
        } 

        public void AdoptAnimals()
        {
            var animalsForAdoption = this.storedAnimals.Where(a => a.CastratedStatus == true || a.CleansedStatus == true).ToList();

            this.adoptedAnimals.AddRange(animalsForAdoption);

            foreach (var animal in animalsForAdoption)
            {
                this.storedAnimals.Remove(animal);
            }
            
        }

        public IReadOnlyCollection<IAnimal> GetAdoptedAnimals()
        {
            return this.adoptedAnimals;
        } 

        public int AdoptedAnimalsCount 
        {
            get { return this.adoptedAnimals.Count; }
        }
    }
}