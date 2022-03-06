// Decompiled with JetBrains decompiler
// Type: Respect.Claims.Claims.ClaimHelper
// Assembly: Respect.Claims, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225A0C90-03DF-4ECB-8577-A9A5E107E2FA
// Assembly location: C:\Users\admin\.nuget\packages\respect.claims\1.0.0\lib\net5.0\Respect.Claims.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Framework.Application;
using Microsoft.AspNetCore.Http;

namespace Framework.Core
{
    public class ClaimHelper : IClaimHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEventLookup _eventLookup;

        public ClaimHelper(IHttpContextAccessor httpContextAccessor, IEventLookup eventLookup)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._eventLookup = eventLookup;
        }

        public ClaimsPrincipal GetUserInfo()
        {
            return this._httpContextAccessor.HttpContext?.User;
        }

        public long GetUserId()
        {
            return -10;
            List<Claim> userClaims = this.GetUserClaims();
            return userClaims != null ? Convert.ToInt64(userClaims.FirstOrDefault<Claim>((Func<Claim, bool>)(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")).Value) : this._eventLookup.Get().ActionUserId;
        }

        private List<Claim> GetUserClaims()
        {
            return this._httpContextAccessor.HttpContext != null ? this._httpContextAccessor.HttpContext.User.Claims.ToList<Claim>() : (List<Claim>)null;
        }

        public string GetUserName()
        {
            return "samira";
            List<Claim> userClaims = this.GetUserClaims();
            return userClaims != null ? userClaims.FirstOrDefault<Claim>((Func<Claim, bool>)(c => c.Type == "name")).Value : this._eventLookup.Get().UserName;
        }

        public string GetFirstName()
        {
            List<Claim> userClaims = this.GetUserClaims();
            return userClaims != null ? userClaims.FirstOrDefault<Claim>((Func<Claim, bool>)(c => c.Type == "nickname")).Value : this._eventLookup.Get().UserName;
        }

        public string GetLastName()
        {
            List<Claim> userClaims = this.GetUserClaims();
            return userClaims != null ? userClaims.FirstOrDefault<Claim>((Func<Claim, bool>)(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname")).Value : this._eventLookup.Get().UserName;
        }
    }
}
