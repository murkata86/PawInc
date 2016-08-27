namespace PawIcn.Models.Commands
{
    using System.Linq;
    using Interfaces;

    public class RegisterCat : Command
    {
        private IAnimalFactory animalFactory;

        public RegisterCat(string[] data, IDatabase database, IAnimalFactory animalFactory) : 
            base(data, database)
        {
            this.animalFactory = animalFactory;
        }

        public override void Execute()
        {
            string name = this.Data[0];
            int age = int.Parse(this.Data[1]);
            int intelligenceCoefficient = int.Parse(this.Data[2]);
            string adoptionCenter = this.Data[3];

            IAnimal animal = this.animalFactory.CreateAnimal("Cat", name, age, intelligenceCoefficient);

            bool ifCenterExists = this.Database.GetAdoptionCenters().
                Any(ac => ac.Name == adoptionCenter);

            if (ifCenterExists)
            {
                IAdoptionCenter adopCenter = this.Database.GetAdoptionCenters().
                    First(ac => ac.Name == adoptionCenter);

                adopCenter.AddAnimal(animal);
            }
        }
    }
}
