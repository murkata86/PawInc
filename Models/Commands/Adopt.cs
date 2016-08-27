namespace PawIcn.Models.Commands
{
    using System.Linq;
    using Interfaces;

    public class Adopt : Command
    {
        public Adopt(string[] data, IDatabase database) : 
            base(data, database) { }

        public override void Execute()
        {
            string adoptionCenterName = this.Data[0];

            bool ifAdoptionCenterExists = this.Database.GetAdoptionCenters().
                Any(ac => ac.Name == adoptionCenterName);

            if (ifAdoptionCenterExists)
            {
                IAdoptionCenter adoptionCenter = this.Database.GetAdoptionCenters().
                    First(ac => ac.Name == adoptionCenterName);

                adoptionCenter.AdoptAnimals();
            }
        }
    }
}
