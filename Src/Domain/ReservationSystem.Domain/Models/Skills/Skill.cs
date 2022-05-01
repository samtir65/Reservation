using Framework.Domain;

namespace ReservationSystem.Domain.Models.Services
{
    public class Skill : AggregateRoot<SkillId>
    {
        public string Name { get; set; }
    }
}