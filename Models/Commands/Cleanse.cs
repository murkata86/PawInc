namespace PawIcn.Models.Commands
{
    using System.Linq;
    using Interfaces;

    public class Cleanse : Command
    {
        public Cleanse(string[] data, IDatabase database) : 
            base(data, database) { }

        public override void Execute()
        {
            string cleanseCenter = this.Data[0];

            bool ifCeleansingCenterExists = this.Database.GetCleansingCenters().
                Any(cc => cc.Name == cleanseCenter);

            if (ifCeleansingCenterExists)
            {
                ICleansingCenter cCenter = this.Database.GetCleansingCenters().
                    First(cc => cc.Name == cleanseCenter);

                cCenter.CleanseAnimals();
            }
        }
    }
}
