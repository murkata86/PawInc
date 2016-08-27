namespace PawIcn.Interfaces
{
    using System.Collections.Generic;

    public interface IDatabase
    {
        void AddAdoptionCenter(IAdoptionCenter adoptionCenter);
        void AddCleasingCenter(ICleansingCenter cleansingCententer);
        void AddCastratingCenter(ICastratingCenter castratingCenter);
        IReadOnlyCollection<ICleansingCenter> GetCleansingCenters();
        IReadOnlyCollection<IAdoptionCenter> GetAdoptionCenters();
        IReadOnlyCollection<ICastratingCenter> GetCastratingCenters();
        string Statistics();
        string CastratingStatistics();
    }
}
