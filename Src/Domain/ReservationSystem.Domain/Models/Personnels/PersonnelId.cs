using Framework.Domain;

namespace ReservationSystem.Domain.Models.Personnels
{
    public class PersonnelId:IdBase<long>
    {
        public PersonnelId(long id):base(id)
        {
            
        }
        protected PersonnelId()
        {
        }
    }
}