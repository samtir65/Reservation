using Framework.Application;
using Framework.Core;
using Framework.Core.Clock;
using System.Collections.Generic;
using ReservationSystem.Domain.Models.Services;
using ReservationSystem.Domain.Models.Personnels;

namespace ReservationSystem.Domain.Models.Reservations.Factories
{
    public static class Factory
    {
        public static Reservation CreateReservation(ReservationId id, IClock createOn, long customerId, List<SkillId> requiredSkills,
            PersonnelId personelId, IClaimHelper claimHelper, IEventPublisher eventPublisher)
        {
            return new Reservation(id, createOn, customerId, requiredSkills, personelId,claimHelper,eventPublisher);
        }
    }
}
