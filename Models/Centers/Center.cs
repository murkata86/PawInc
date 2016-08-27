namespace PawIcn.Models.Centers
{
    using PawIcn.Interfaces;
    public abstract class Center : ICenter
    {
        private string name;

        protected Center(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }

            private set { this.name = value; }
        }
    }
}
