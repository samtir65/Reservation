using System;
using System.Collections.Generic;
using Framework.Application;
using Framework.Core;
using Framework.Test;
using ReservationSystem.Domain.Models.Personnels;
using ReservationSystem.Domain.TestsUtils.Models.Assigneds;

namespace ReservationSystem.Domain.TestsUtils.Models.Personnels
{
    public class PersonnelTestBuilder
    {
        public PersonnelId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<AssignedSkill> Skills { get; set; }
        public IEventPublisher EventPublisher { get; set; }
        public IClaimHelper ClaimHelper { get; set; }
        public PersonnelTestBuilder()
        {
            Id = new PersonnelId(GenerateRandom.Number());
            FirstName = GenerateRandom.String();
            LastName = GenerateRandom.String();
            Skills = new List<AssignedSkill>(){new AssigenedSkillTestBuilder().Build()};
            EventPublisher = new FakeEventPublisher();
            ClaimHelper = new ClaimHelperStub();
        }
        public Personnel Build()
        {
            return new Personnel(Id,EventPublisher,ClaimHelper.GetUserId(),Skills,FirstName,LastName);
        }
    }
}