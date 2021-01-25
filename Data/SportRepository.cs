using System;
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
            if (sport == null)
            {
                throw new ArgumentNullException(nameof(sport));
            }
            _context.Sports.Add(sport);
        }

        public void DeleteSport(Sport sport)
        {
            if (sport == null)
            {
                throw new ArgumentNullException(nameof(sport));
            }
            _context.Sports.Remove(sport);
        }

        public IEnumerable<Sport> GetAllSports()
        {
            return _context.Sports.ToList();
        }

        public Sport GetSportByName(string sportName)
        {
            return _context.Sports.FirstOrDefault(p => p.Name == sportName);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);

        }

        public void UpdateSport(Sport sport)
        {

        }
    }
}