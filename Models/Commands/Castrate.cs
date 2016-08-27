namespace PawIcn.Models.Commands
{
    using System.Linq;
    using Interfaces;

    public class Castrate : Command
    {
        public Castrate(string[] data, IDatabase database) : 
            base(data, database) { }

        public override void Execute()
        {
            string castrateCenterName = this.Data[0];

            bool ifCastrateCenterExists = this.Database.GetCastratingCenters().
                Any(cc => cc.Name == castrateCenterName);

            if (ifCastrateCenterExists)
            {
                var castrateCenter = this.Database.GetCastratingCenters().
                    First(cc => cc.Name == castrateCenterName);

                castrateCenter.CastrateAnimals();
            }
        }
    }
}
