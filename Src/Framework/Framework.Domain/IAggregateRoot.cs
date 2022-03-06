// Decompiled with JetBrains decompiler
// Type: Respect.Domain.IAggregateRoot
// Assembly: Respect.Domain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 858114E4-2B6F-41BD-A422-542E083FDAB0
// Assembly location: C:\Users\admin\.nuget\packages\respect.domain\1.0.0\lib\net5.0\Respect.Domain.dll

using System.Collections.Generic;

namespace Framework.Domain
{
    public interface IAggregateRoot
    {
        void Publish<TEvent>(TEvent @event) where TEvent : DomainEvent;

        IReadOnlyList<DomainEvent> GetChanges();

        void ClearChanges();
    }
}