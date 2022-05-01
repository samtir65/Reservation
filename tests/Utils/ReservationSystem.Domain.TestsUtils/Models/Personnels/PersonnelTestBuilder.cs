using System;
using System.Collections.Generic;
using Framework.Test;
using ReservationSystem.Domain.Models.AvailableServices;
using ReservationSystem.Domain.Models.Customers;
using ReservationSystem.Domain.Models.Personnels;

namespace ReservationSystem.Domain.TestsUtils.Models.Personnels
{
    public class PersonnelTestBuilder
    {
        public PersonnelId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<AvailableService> AvailableServices { get; set; }

        public PersonnelTestBuilder()
        {
            Id = new PersonnelId(GenerateRandom.Number());
            FirstName = GenerateRandom.String();
            LastName = GenerateRandom.String();
           
        }
        public Personnel build()
        {
        }
    }
}