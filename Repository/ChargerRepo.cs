using Practice.Models;

namespace Practice.Repository
{
    public class ChargerRepo : IChargerRepo
    {
        private readonly DatabaseContext _context;
        public ChargerRepo(DatabaseContext context)
        {
            this._context = context;
        }
        public bool CreateCharger(Charger charger)
        {

            _context.Chargers.Add(charger);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteCharger(int id)
        {
            try
            {
                var chaged = _context.Chargers.FirstOrDefault(c => c.Id == id);
                _context.Chargers.Remove(chaged);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex) { return false; }

        }

        public IEnumerable<Charger> GetAll()
        {
            return _context.Chargers.ToList();
        }

        public Charger GetById(int id)
        {
            return _context.Chargers.FirstOrDefault(x => x.Id == id);
        }

        public bool UpdateCharger(Charger charger,int id)
        {
            var dekho = _context.Chargers.Find(charger.Id);


            if(charger.Id == id)
            {
                dekho.Name = charger.Name;
                dekho.Description = charger.Description;
                dekho.Price = charger.Price;

                _context.Chargers.Update(dekho);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
