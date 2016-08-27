namespace PawIcn.Models.Animals
{
    public class Cat : Animal
    {
        private int intelligenceCoefficient;
        public Cat(string name, int age, int intelligenceCoefficient) : 
            base(name, age)
        {
            this.IntelligenceCoefficient = intelligenceCoefficient;
        }

        public int IntelligenceCoefficient
        {
            get { return this.intelligenceCoefficient; }

            private set { this.intelligenceCoefficient = value; }
        }
    }
}
