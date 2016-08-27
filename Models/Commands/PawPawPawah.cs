namespace PawIcn.Models.Commands
{
    using System;
    using Interfaces;
    using UI;

    public class PawPawPawah : Command
    {
        private OutputWriter writer;

        public PawPawPawah(string[] data, IDatabase database, OutputWriter writer) :
            base(data, database)
        {
            this.writer = writer;
        }

        public override void Execute()
        {
            this.writer.WriteOutput(this.Database.Statistics());
            Environment.Exit(0);
        }
    }
}
