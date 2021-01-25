using System.Collections.Generic;
using AmsterdamSportInc.Models;

namespace AmsterdamSportInc.Data
{
    public interface IMemberToSportRepository
    {
        bool SaveChanges();
        void AssignMemberToSport(MemberToSport memberToSport);
        void DeleteMemberToSport(MemberToSport memberToSport);
        public bool CheckForDuplicaion(int id, string name);
    }
}