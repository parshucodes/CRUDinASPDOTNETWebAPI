using Practice.Models;

namespace Practice.Repository
{
    public interface IChargerRepo
    {
        IEnumerable<Charger> GetAll();
        Charger GetById (int id);
        bool UpdateCharger(Charger charger, int id);
        bool DeleteCharger(int id);
        bool CreateCharger(Charger charger);

    }
}
