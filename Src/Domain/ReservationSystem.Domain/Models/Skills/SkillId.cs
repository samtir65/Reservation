using Framework.Domain;

namespace ReservationSystem.Domain.Models.Services
{
    public class SkillId:IdBase<long>
    {
        public SkillId(long id):base(id)
        {
            
        } 
        protected SkillId()
        {
            
        }
    }
}