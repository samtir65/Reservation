namespace ReservationSystem.Domain.Models.AssignedServices
{
    public class AssigenedSkills
    {
        public long SkillId { get; set; }
        public decimal Amount { get; set; }

        public AssigenedSkills(long skillId, decimal amount)
        {
            SkillId = skillId;
            Amount = amount;
        }
        protected AssigenedSkills()
        {
        }
    }

}
