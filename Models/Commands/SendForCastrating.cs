namespace PawIcn.Models.Commands
{
    using System.Linq;
    using Interfaces;

    public class SendForCastrating : Command
    {
        public SendForCastrating(string[] data, IDatabase database) : 
            base(data, database) { }

        public override void Execute()
        {
            string adoptionCenterName = this.Data[0];
            string castratingCenterName = this.Data[1];

            bool ifAdoptionCenterExists = this.Database.GetAdoptionCenters().
                Any(ac => ac.Name == adoptionCenterName);

            bool ifCastratingCenterExists = this.Database.GetCastratingCenters().
                Any(cc => cc.Name == castratingCenterName);

            if (ifCastratingCenterExists && ifAdoptionCenterExists)
            {
                IAdoptionCenter adopCenter = this.Database.GetAdoptionCenters().
                    First(ac => ac.Name == adoptionCenterName);

                ICastratingCenter casCenter = this.Database.GetCastratingCenters().
                    First(cc => cc.Name == castratingCenterName);

                adopCenter.SendAnimalsForCastrating(casCenter);
            }
        }
    }
}
