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
            throw new System.NotImplementedException();
        }

        public void DeleteMember(Member member)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Member> GetAllMembers()
        {
            return _context.Members.ToList();
        }

        public Member GetMemberById(int id)
        {
            return _context.Members.FirstOrDefault(p => p.Id == id);
        }

        public void UpdateMember(Member member)
        {
            throw new System.NotImplementedException();
        }
    }
}