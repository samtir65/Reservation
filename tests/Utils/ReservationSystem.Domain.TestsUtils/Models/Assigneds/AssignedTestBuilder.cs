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
        public AssigenedService Build()
        {
            return new AssigenedService(SkillId,Amount);
        }
    }
}