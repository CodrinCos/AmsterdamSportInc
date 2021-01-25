using System.Collections.Generic;
using AmsterdamSportInc.Models;

namespace AmsterdamSportInc.Data
{
    public interface IMemberToSportRepository
    {
        bool SaveChanges();
        void AssignMemberToSport(MemberToSport memberToSport);
        void DeleteMemberToSport(MemberToSport memberToSport);
        bool CheckForDuplicaion(int id, string name);
        IEnumerable<MemberToSport> GetSportsForAMember(int id);
        bool CheckIfSportExists(string sportName);
        bool CheckIfPersonExists(int id);
    }
}