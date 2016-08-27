namespace PawIcn.Models.Commands
{
    using Interfaces;
    using Centers;

    public class RegisterCleansingCenter : Command
    {
        public RegisterCleansingCenter(string[] data, IDatabase database) : 
            base(data, database) { }

        public override void Execute()
        {
            string name = this.Data[0];

            ICleansingCenter cleansingCenter = new CleansingCenter(name);

            this.Database.AddCleasingCenter(cleansingCenter);
        }
    }
}
