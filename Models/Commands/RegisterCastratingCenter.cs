namespace PawIcn.Models.Commands
{
    using Interfaces;
    using Centers;

    public class RegisterCastratingCenter : Command
    {
        public RegisterCastratingCenter(string[] data, IDatabase database) : 
            base(data, database) { }
        public override void Execute()
        {
            string name = this.Data[0];

            ICastratingCenter castratingCenter = new CastratingCenter(name);

            this.Database.AddCastratingCenter(castratingCenter);
        }
    }
}
