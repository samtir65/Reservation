// Decompiled with JetBrains decompiler
// Type: Respect.Core.Events.UsersInfo.IEventLookup
// Assembly: Respect.Core, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8C733E-D4A0-4C42-95C0-31B55392E3C3
// Assembly location: C:\Users\admin\.nuget\packages\respect.core\1.0.1\lib\net5.0\Respect.Core.dll

namespace Framework.Application
{
    public interface IEventLookup
    {
        IUserInfo Get();
        void SetUserInfo<T>(T @event) where T : IUserInfo;
    }
}