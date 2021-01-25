using System.Collections.Generic;
using AmsterdamSportInc.Models;

namespace AmsterdamSportInc.Data
{
    public interface IMemberToSportRepository
    {
        void AssignMemberToSport(MemberToSport memberToSport);
        void DeleteMemberToSport(MemberToSport memberToSport);
    }
}