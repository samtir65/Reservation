// Decompiled with JetBrains decompiler
// Type: Respect.Claims.Claims.IClaimHelper
// Assembly: Respect.Claims, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225A0C90-03DF-4ECB-8577-A9A5E107E2FA
// Assembly location: C:\Users\admin\.nuget\packages\respect.claims\1.0.0\lib\net5.0\Respect.Claims.dll

using System.Security.Claims;

namespace Framework.Application
{
    public interface IClaimHelper
    {
        string GetUserName();
        string GetFirstName();
        string GetLastName();
        long GetUserId();
        ClaimsPrincipal GetUserInfo();
    }
}