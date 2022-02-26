using System.Data;
using Framework.Application;
using NHibernate;

namespace Framework.NH
{
    public class NhUnitOfWork:IUnitOfWork
    {
        private readonly ISession _session;
        public NhUnitOfWork(ISession session)
        {
            this._session = session;
        }
        public void Begin()
        {
            _session.Transaction.Begin(IsolationLevel.ReadCommitted);
        }

        public void Commit()
        {
            _session.Transaction.Commit();

        }

        public void Rollback()
        {
            _session.Transaction.Rollback();
        }
    }
}
