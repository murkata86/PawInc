namespace PawIcn.Models.Commands
{
    using Interfaces;
    using UI;

    public class CastrationStatistics : Command
    {
        private OutputWriter writer;
        public CastrationStatistics(string[] data, IDatabase database, OutputWriter writer) : 
            base(data, database)
        {
            this.writer = writer;
        }
        public override void Execute()
        {
            this.writer.WriteOutput(this.Database.CastratingStatistics());
        }
    }
}
