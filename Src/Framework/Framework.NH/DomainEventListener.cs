// Decompiled with JetBrains decompiler
// Type: Respect.NH.DomainEventListener
// Assembly: Respect.NH, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: DA4DCF3D-5563-415D-B353-FC11CFB50050
// Assembly location: C:\Users\admin\.nuget\packages\respect.nh\1.0.1\lib\net5.0\Respect.NH.dll

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Framework.Domain;
using NHibernate;
using NHibernate.Event;

namespace Framework.NH
{
    public class DomainEventListener : IPreInsertEventListener, IPreUpdateEventListener, IPreCollectionUpdateEventListener, IPreCollectionRecreateEventListener
    {
        public Task<bool> OnPreInsertAsync(
          PreInsertEvent @event,
          CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> OnPreUpdateAsync(
          PreUpdateEvent @event,
          CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public bool OnPreInsert(PreInsertEvent @event)
        {
            this.InsertEvents((ISession)@event.Session, @event.Entity);
            return false;
        }

        private static void ConvertToEnglishNumber(object entity)
        {
            foreach (PropertyInfo property in entity.GetType().GetProperties())
            {
                object obj = property.GetValue(entity);
                if (obj is string)
                {
                    string persianString = obj.ToString();
                    property.SetValue(entity, (object)persianString.ConvertNumbersToEnglish());
                }
            }
        }

        public bool OnPreUpdate(PreUpdateEvent @event)
        {
            this.InsertEvents((ISession)@event.Session, @event.Entity);
            return false;
        }

        public Task<bool> OnPreDeleteAsync(
          PreDeleteEvent @event,
          CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task OnPreUpdateCollectionAsync(
          PreCollectionUpdateEvent @event,
          CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void OnPreUpdateCollection(PreCollectionUpdateEvent @event)
        {
            this.InsertEvents((ISession)@event.Session, @event.AffectedOwnerOrNull);
        }

        private void InsertEvents(ISession session, object entity)
        {
            if (!(entity is IAggregateRoot aggregateRoot))
                return;
            IReadOnlyList<DomainEvent> changes = aggregateRoot.GetChanges();
            if (!changes.Any<DomainEvent>())
                return;
            foreach (DomainEvent targetEvent in (IEnumerable<DomainEvent>)changes)
            {
                SqlCommand sqlCommand = SqlCommandFactory.FromEvent(targetEvent);
                sqlCommand.Connection = session.Connection as SqlConnection;
                session.GetCurrentTransaction().Enlist((DbCommand)sqlCommand);
                sqlCommand.ExecuteNonQuery();
            }
            aggregateRoot.ClearChanges();
        }

        public Task OnPreRecreateCollectionAsync(
          PreCollectionRecreateEvent @event,
          CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void OnPreRecreateCollection(PreCollectionRecreateEvent @event)
        {
            if (!(@event is IAggregateRoot aggregateRoot))
                return;
            IReadOnlyList<DomainEvent> changes = aggregateRoot.GetChanges();
            if (!changes.Any<DomainEvent>())
                return;
            foreach (DomainEvent targetEvent in (IEnumerable<DomainEvent>)changes)
            {
                SqlCommand sqlCommand = SqlCommandFactory.FromEvent(targetEvent);
                sqlCommand.Connection = (@event as ISession).Connection as SqlConnection;
                @event.Session.GetCurrentTransaction().Enlist((DbCommand)sqlCommand);
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
