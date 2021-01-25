using System.Collections.Generic;
using AmsterdamSportInc.Models;

namespace AmsterdamSportInc.Data
{
    public interface ISportRepository
    {
        bool SaveChanges();
        IEnumerable<Sport> GetAllSports();
        Sport GetSportByName(string sportName);
        void CreateSport(Sport sport);
        void UpdateSport(Sport sport);
        void DeleteSport(Sport sport);
    }
}