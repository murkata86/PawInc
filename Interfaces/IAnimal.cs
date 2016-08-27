namespace PawIcn.Interfaces
{
    public interface IAnimal
    {
        string Name { get; }
        int Age { get; }
        bool CleansedStatus { get; set; }
        bool CastratedStatus { get; set; }
    }
}
