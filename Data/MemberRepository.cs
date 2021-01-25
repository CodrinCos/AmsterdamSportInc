using System;
using System.Collections.Generic;
using System.Linq;
using AmsterdamSportInc.Models;

namespace AmsterdamSportInc.Data
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AmsterdamSportIncContext _context;

        public MemberRepository(AmsterdamSportIncContext context)
        {
            _context = context;
        }
        public void CreateMember(Member member)
        {
            if (member == null)
            {
                throw new ArgumentNullException(nameof(member));
            }
            _context.Members.Add(member);
        }

        public void DeleteMember(Member member)
        {
            if (member == null)
            {
                throw new ArgumentNullException(nameof(member));
            }
            _context.Members.Remove(member);
        }

        public IEnumerable<Member> GetAllMembers()
        {
            return _context.Members.ToList();
        }

        public Member GetMemberById(int id)
        {
            return _context.Members.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public void UpdateMember(Member member)
        {

        }
    }
}