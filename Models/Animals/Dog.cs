namespace PawIcn.Models.Animals
{
    public class Dog : Animal
    {
        private int amountOfCommands;
        public Dog(string name, int age, int amountOfCommands) : 
            base(name, age)
        {
            this.AmountOfCommands = amountOfCommands;
        }

        public int AmountOfCommands
        {
            get { return this.amountOfCommands; }

            private set { this.amountOfCommands = value; }
        }
    }
}
