using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Framework.Core.Utilities;
using Framework.Domain;
using NHibernate;
using NHibernate.Event;

namespace Framework.NH
{
    public class DomainEventListener : IPreInsertEventListener, IPreUpdateEventListener
                                       , IPreCollectionUpdateEventListener, IPreCollectionRecreateEventListener
    {
        public Task<bool> OnPreInsertAsync(PreInsertEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public Task<bool> OnPreUpdateAsync(PreUpdateEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public bool OnPreInsert(PreInsertEvent @event)
        {
            InsertEvents(@event.Session, @event.Entity);
            return false;
        }

        private static void ConvertToEnglishNumber(object entity)
        {
            foreach (var propertyInfo in entity.GetType().GetProperties())
            {
                var valueOfProperty = propertyInfo.GetValue(entity);
                if (valueOfProperty is string)
                {
                    var stringValue = valueOfProperty.ToString();
                    propertyInfo.SetValue(entity, stringValue.ConvertNumbersToEnglish());
                }
            }
        }

        public bool OnPreUpdate(PreUpdateEvent @event)
        {
            InsertEvents(@event.Session, @event.Entity);
            return false;
        }

        public Task<bool> OnPreDeleteAsync(PreDeleteEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task OnPreUpdateCollectionAsync(PreCollectionUpdateEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void OnPreUpdateCollection(PreCollectionUpdateEvent @event)
        {
            InsertEvents(@event.Session, @event.AffectedOwnerOrNull);
        }
        private void InsertEvents(ISession session, object entity)
        {
            if (entity is IAggregateRoot aggregateRoot)
            {
                var changes = aggregateRoot.GetChanges();
                if (!changes.Any()) return;

                foreach (var targetEvent in changes)
                {
                    var command = SqlCommandFactory.FromEvent(targetEvent);
                    command.Connection = (session as ISession).Connection as SqlConnection;
                    session.Transaction.Enlist(command);
                    command.ExecuteNonQuery();
                }
                aggregateRoot.ClearChanges();
            }
        }
        public Task OnPreRecreateCollectionAsync(PreCollectionRecreateEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void OnPreRecreateCollection(PreCollectionRecreateEvent @event)
        {
            if (@event is IAggregateRoot aggregateRoot)
            {
                var changes = aggregateRoot.GetChanges();
                if (!changes.Any()) return;

                foreach (var targetEvent in changes)
                {
                    var command = SqlCommandFactory.FromEvent(targetEvent);
                    command.Connection = (@event as ISession).Connection as SqlConnection;
                    @event.Session.Transaction.Enlist(command);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
