using ReservationSystem.Domain.Models.AssignedServices;

namespace ReservationSystem.Domain.TestsUtils.Models.Assigneds
{
    public class AssignedTestBuilder
    {
        public long SkillId { get; set; }
        public decimal Amount { get; set; }
        public AssignedTestBuilder()
        {

        }
        public AssigenedSkills Build()
        {
            return new AssigenedSkills(SkillId,Amount);
        }
    }
}