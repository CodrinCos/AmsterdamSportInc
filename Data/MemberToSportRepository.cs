using System;
using System.Collections.Generic;
using System.Linq;
using AmsterdamSportInc.Models;
using Microsoft.EntityFrameworkCore;

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
            }
            else
            {
                return true;
            }
        }

        public bool CheckIfSportExists(string sportName)
        {
            var check = _context.Sports.FirstOrDefault(p => p.Name == sportName);
            if (check != null)
            {
                return true;
            }
            return false;
        }

        public bool CheckIfPersonExists(int id)
        {
            var check = _context.Members.FirstOrDefault(p => p.Id == id);
            if(check != null)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<MemberToSport> GetSportsForAMember(int id)
        {
            return _context.MemberToSport.Where(p => p.MemberId == id).ToList();
        }

        public void DeleteMemberToSport(MemberToSport memberToSport)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);

        }

        public bool CheckIfFootballAllowed(int memberId)
        {
            var sports = GetSportsForAMember(memberId);
            if (sports.Count() < 2) 
            {
                return true;
            }
            return false;

        }
    }
}