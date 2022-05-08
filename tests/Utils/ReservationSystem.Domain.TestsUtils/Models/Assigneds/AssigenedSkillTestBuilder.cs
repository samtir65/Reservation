using ReservationSystem.Domain.Models.Personnels;

namespace ReservationSystem.Domain.TestsUtils.Models.Assigneds
{
    public class AssigenedSkillTestBuilder
    {
        public long SkillId { get; set; }
        public decimal Amount { get; set; }
        public AssigenedSkillTestBuilder()
        {

        }
        public AssignedSkill Build()
        {
            return new AssignedSkill(SkillId,Amount);
        }
    }
}