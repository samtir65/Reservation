namespace ReservationSystem.Domain.Models.Personnels
{
    public interface IPersonnelRepository
    {
        void Create(Personnel personnel);
        Personnel GetBy(PersonnelId personnelId);
        PersonnelId GetNextId();
    }
}