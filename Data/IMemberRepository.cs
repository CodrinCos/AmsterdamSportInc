using System.Collections.Generic;
using AmsterdamSportInc.Models;

namespace AmsterdamSportInc.Data
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetAllMembers();
        Sport GetMemberById(int Id);
        void CreateMember(Member member);
        void UpdateMember(Member member);
        void DeleteMember(Member member);
    }
}