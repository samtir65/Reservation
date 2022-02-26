// Decompiled with JetBrains decompiler
// Type: Respect.Domain.ValueObjectBase
// Assembly: Respect.Domain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 858114E4-2B6F-41BD-A422-542E083FDAB0
// Assembly location: C:\Users\admin\.nuget\packages\respect.domain\1.0.0\lib\net5.0\Respect.Domain.dll

using Framework.Core;

namespace Framework.Domain
{
    public abstract class ValueObjectBase
    {
        public override bool Equals(object obj)
        {
            return !(obj.GetType() != this.GetType()) && EqualsBuilder.ReflectionEquals((object)this, obj);
        }

        public override int GetHashCode()
        {
            return HashCodeBuilder.ReflectionHashCode((object)this);
        }
    }
}