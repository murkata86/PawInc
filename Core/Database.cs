namespace PawIcn.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Interfaces;

    public class Database : IDatabase
    {
        private List<IAdoptionCenter> adoptionCenters;
        private List<ICleansingCenter> cleansingCenters;
        private List<ICastratingCenter> castratingCenters;

        public Database()
        {
            this.adoptionCenters = new List<IAdoptionCenter>();
            this.cleansingCenters = new List<ICleansingCenter>();
            this.castratingCenters = new List<ICastratingCenter>();
        }

        public void AddAdoptionCenter(IAdoptionCenter adoptionCenter)
        {
            this.adoptionCenters.Add(adoptionCenter);
        }

        public void AddCleasingCenter(ICleansingCenter cleansingCententer)
        {
            this.cleansingCenters.Add(cleansingCententer);
        }

        public void AddCastratingCenter(ICastratingCenter castratingCenter)
        {
            this.castratingCenters.Add(castratingCenter);
        }

        public IReadOnlyCollection<IAdoptionCenter> GetAdoptionCenters()
        {
            return this.adoptionCenters;
        }

        public IReadOnlyCollection<ICleansingCenter> GetCleansingCenters()
        {
            return this.cleansingCenters;
        }

        public IReadOnlyCollection<ICastratingCenter> GetCastratingCenters()
        {
            return this.castratingCenters;
        }

        public string Statistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("Paw Incorporative Regular Statistics")).
                AppendLine(string.Format("Adoption Centers: {0}", this.adoptionCenters.Count)).
                AppendLine(string.Format("Cleansing Centers: {0}", this.cleansingCenters.Count)).
                AppendLine(string.Format("Adopted Animals: {0}", 
                this.GetAdoptionCenters().Sum(a => a.AdoptedAnimalsCount) == 0 ? 
                "None" : string.Join(", ", 
                this.GetAdoptionCenters().SelectMany(ac => ac.GetAdoptedAnimals().OrderBy(a => a.Name))))).
                AppendLine(string.Format("Cleansed Animals: {0}", this.GetCleansingCenters().Sum(c => c.CleansedAnimals) == 0 ?
                "None" : string.Join(", ", 
                this.GetCleansingCenters().SelectMany(cc => cc.GetCleansedAnimals().OrderBy(a => a.Name))))).
                AppendLine(string.Format("Animals Awaiting Adoption: {0}", 
                this.GetAdoptionCenters().Sum(a => a.AnimalsForAdoption().Count))).
                Append(string.Format("Animals Awaiting Cleansing: {0}", 
                this.GetCleansingCenters().Sum(c => c.AnimalsWaitngForCleansing().Count)));

            return sb.ToString();
        }

        public string CastratingStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("Paw Inc. Regular Castration Statistics")).
                AppendLine(string.Format("Castration Centers: {0}", this.cleansingCenters.Count)).
                Append(string.Format("Castrated Animals: {0}",
                this.GetCastratingCenters().Sum(c => c.CastratedAnimalsCount()) == 0 ?
                "None" : string.Join(", ", 
                this.GetCastratingCenters().SelectMany(cc => cc.CastratedAnimals().OrderBy(a => a.Name)))));

            return sb.ToString();
        }
    }
}