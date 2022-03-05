// Decompiled with JetBrains decompiler
// Type: Respect.Core.Events.UsersInfo.EventLookup
// Assembly: Respect.Core, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8C733E-D4A0-4C42-95C0-31B55392E3C3
// Assembly location: C:\Users\admin\.nuget\packages\respect.core\1.0.1\lib\net5.0\Respect.Core.dll

using Framework.Application;

namespace Framework.Core
{
    public class EventLookup : IEventLookup
    {
        private IUserInfo _userInfo;

        public IUserInfo Get()
        {
            return this._userInfo;
        }

        public void SetUserInfo<T>(T @event) where T : IUserInfo
        {
            this._userInfo = (IUserInfo)@event;
        }
    }
}