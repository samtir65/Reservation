namespace ReservationSystem.Domain.Models.AssignedServices
{
    public class AssigenedService
    {
        public long SkillId { get; set; }
        public decimal Amount { get; set; }

        public AssigenedService(long skillId, decimal amount)
        {
            SkillId = skillId;
            Amount = amount;
        }
        protected AssigenedService()
        {
        }
    }

}
