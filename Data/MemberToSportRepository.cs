using System.Collections.Generic;
using AmsterdamSportInc.Models;

namespace AmsterdamSportInc.Data
{
    public class MemberToSportRepository : IMemberToSportRepository
    {
        private readonly AmsterdamSportIncContext _context;

        public MemberToSportRepository(AmsterdamSportIncContext context)
        {
            _context = context;
        }
        public void AssignMemberToSport(MemberToSport memberToSport)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteMemberToSport(MemberToSport memberToSport)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);

        }
    }
}