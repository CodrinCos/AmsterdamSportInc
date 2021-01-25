using System;
using System.Collections.Generic;
using System.Linq;
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
            if (memberToSport == null)
            {
                throw new ArgumentNullException(nameof(memberToSport));
            }
            _context.MemberToSport.Add(memberToSport);
        }

        public bool CheckForDuplicaion(int id, string name)
        {
            var check = _context.MemberToSport.FirstOrDefault(p => p.MemberId == id && p.SportName == name);
            if (check == null)
            {
                return false;
            } else
            {
                return true;
            }
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