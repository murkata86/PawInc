namespace PawIcn.Models.Commands
{
    using System.Linq;
    using Interfaces;

    public class SendForCleansing : Command
    {
        public SendForCleansing(string[] data, IDatabase database) : 
            base(data, database) { }

        public override void Execute()
        {
            string adoptionCenter = this.Data[0];
            string cleansingCenter = this.Data[1];

            bool ifAdoptionCenterExist = this.Database.GetAdoptionCenters().
                Any(ac => ac.Name == adoptionCenter);

            bool ifCleansingCenterExist = this.Database.GetCleansingCenters().
                Any(cc => cc.Name == cleansingCenter);

            if (ifAdoptionCenterExist && ifCleansingCenterExist)
            {
                IAdoptionCenter aCenter = this.Database.GetAdoptionCenters().
                    First(ac => ac.Name == adoptionCenter);

                ICleansingCenter cCenter = this.Database.GetCleansingCenters().
                    First(cc => cc.Name == cleansingCenter);

                aCenter.SendAnimalsForCleansing(cCenter);
            }
        }
    }
}
