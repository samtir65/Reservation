// Decompiled with JetBrains decompiler
// Type: Respect.Test.Doubles.ClaimHelperStub
// Assembly: Respect.Test.Doubles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E3EE3AA9-3493-42F4-870B-E3D7DDDC9B7F
// Assembly location: C:\Users\admin\.nuget\packages\respect.test.doubles\1.0.0\lib\net5.0\Respect.Test.Doubles.dll

using System.Security.Claims;
using Framework.Application;
using Framework.Core;

namespace Framework.Test
{
    public class ClaimHelperStub : IClaimHelper
    {
        public string GetUserName()
        {
            return "John@22";
        }

        public string GetFirstName()
        {
            return "John";
        }

        public string GetLastName()
        {
            return "Lando";
        }

        public long GetUserId()
        {
            return 10;
        }

        public ClaimsPrincipal GetUserInfo()
        {
            return (ClaimsPrincipal)null;
        }
    }
}