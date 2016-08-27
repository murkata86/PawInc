namespace PawIcn.Models.Commands
{
    using Interfaces;
    public abstract class Command : IExecutable
    {
        private IDatabase database;
        private string[] data;
        protected Command(string[] data, IDatabase database)
        {
            this.Data = data;
            this.database = database;
        }

        public string[] Data
        {
            get { return this.data; }
            private set { this.data = value; }
        }

        public IDatabase Database
        {
            get { return this.database; }

            private set { this.database = value; }
        }

        public abstract void Execute();
    }
}
