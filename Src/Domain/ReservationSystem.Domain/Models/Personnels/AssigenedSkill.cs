using Framework.Domain;

namespace ReservationSystem.Domain.Models.Personnels
{
    public class AssignedSkill : ValueObjectBase
    {
        public long SkillId { get; set; }
        public decimal Amount { get; set; }

        public AssignedSkill(long skillId, decimal amount)
        {
            SkillId = skillId;
            Amount = amount;
        }
        protected AssignedSkill()
        {
        }
    }

}
