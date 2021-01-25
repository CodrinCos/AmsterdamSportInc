using System.Collections.Generic;
using System.Linq;
using AmsterdamSportInc.Models;

namespace AmsterdamSportInc.Data
{
    public class SportRepository : ISportRepository
    {
        private readonly AmsterdamSportIncContext _context;

        public SportRepository(AmsterdamSportIncContext context)
        {
            _context = context;
        }
        public void CreateSport(Sport sport)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteSport(Sport sport)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Sport> GetAllSports()
        {
            return _context.Sports.ToList();
        }

        public Sport GetSportByName(string sportName)
        {
            return _context.Sports.FirstOrDefault(p => p.Name == sportName);
        }

        public void UpdateSport(Sport sport)
        {
            throw new System.NotImplementedException();
        }
    }
}