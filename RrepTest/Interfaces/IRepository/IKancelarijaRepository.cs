using RrepTest.Models;


namespace RrepTest.Interfaces.IRepository
{
    public interface IKancelarijaRepository : IRepository<Kancelarija>
    {
        Kancelarija GeetFromDescription(string name);
        void KreiranjeKancelarije(Kancelarija input);

        bool ProvjeraPostojanjaKancelarije(int id);
    }
}
