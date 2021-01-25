using AmsterdamSportInc.Models;
using Microsoft.EntityFrameworkCore;

namespace AmsterdamSportInc.Data
{
    public class AmsterdamSportIncContext : DbContext
    {
        public AmsterdamSportIncContext(DbContextOptions<AmsterdamSportIncContext> opt) : base(opt)
        {

        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<MemberToSport> MemberToSport { get; set; }

    }
}