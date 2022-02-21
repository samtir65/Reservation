using System;
using System.Collections.Generic;
using System.Transactions;
using Framework.NH;
using NHibernate;
using NHibernate.Engine;
using NHibernate.Type;
using ReservationSystem.Persistence.NH.Mapping.Reservations;

namespace ReservationSystem.NH.Tests.Integration.Reservations
{
    public abstract class BasePersistenceTest : IDisposable
    {
        public ISession Session { get; private set; }
        private readonly TransactionScope _scope;

        protected BasePersistenceTest()
        {
            var filterDef = new FilterDefinition("Filter", null, new Dictionary<string, IType>
                {{"isDeletedParam", NHibernateUtil.Boolean}}, false);

            var isActiveFilterDef = new FilterDefinition("IsActiveFilter", null, new Dictionary<string, IType>
                {{"isActiveParam", NHibernateUtil.Boolean}}, false);

            var sessionFactory = SessionFactoryBuilder.CreateByConnectionString(@"Data Source=.;Initial Catalog=ReservationSystem;User Id=sa;password=123;",
                typeof(ReservationMapping).Assembly, "ReservationSystem", filterDef, isActiveFilterDef);

            this.Session = sessionFactory.OpenSession();
            Session.EnableFilter("Filter").SetParameter("isDeletedParam", false);
            Session.EnableFilter("IsActiveFilter").SetParameter("isActiveParam", true);
            _scope = new TransactionScope();
        }

        public void Dispose()
        {
            _scope?.Dispose();
            Session?.Dispose();
        }
    }
}