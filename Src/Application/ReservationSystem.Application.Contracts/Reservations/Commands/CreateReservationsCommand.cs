using Framework.Application;
using ReservationSystem.Domain.Models.Personnels;
using ReservationSystem.Domain.Models.Services;
using System;
using System.Collections.Generic;

namespace ReservationSystem.Application.Contracts.Reservations.Commands
{
    public class CreateReservationsCommand:ICommand
    {
        public long CustomerId { get;  set; }
        public List<SkillId> RequiredSkills { get; set; }
        public PersonnelId PersonelId { get; set; }

        public CreateReservationsCommand(long customerId, List<SkillId> requiredSkills, PersonnelId personelId)
        {
            CustomerId = customerId;
            RequiredSkills = requiredSkills;
            PersonelId = personelId;
        }
    }
}
