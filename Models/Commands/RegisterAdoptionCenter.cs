namespace PawIcn.Models.Commands
{
    using Interfaces;
    using Centers;

    public class RegisterAdoptionCenter : Command
    {
        public RegisterAdoptionCenter(string[] data, IDatabase database) : 
            base(data, database) { }
        public override void Execute()
        {
            string name = this.Data[0];

            IAdoptionCenter adoptionCenter = new AdoptionCenter(name);
            
            this.Database.AddAdoptionCenter(adoptionCenter);
        }
    }
}
