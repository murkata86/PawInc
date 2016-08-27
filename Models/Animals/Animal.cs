namespace PawIcn.Models.Animals
{
    using PawIcn.Interfaces;
    public abstract class Animal : IAnimal
    {
        private string name;
        private int age;
        private bool cleansedStatus;
        private bool castratedStatus;

        protected Animal(string name, int age)
        {
            this.Name = name;
            this.Age = age;

            this.CleansedStatus = false;
            this.CastratedStatus = false;
        }

        public string Name
        {
            get { return this.name; }

            private set { this.name = value; }
        }

        public int Age
        {
            get { return this.age; }

            private set { this.age = value; }
        }

        public bool CleansedStatus
        {
            get { return this.cleansedStatus; }

            set { this.cleansedStatus = value; }
        }

        public bool CastratedStatus
        {
            get { return this.castratedStatus; }

            set {this.castratedStatus = value;}
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
