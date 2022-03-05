// Decompiled with JetBrains decompiler
// Type: Respect.Http.IHttpClientHelper
// Assembly: Respect.Http, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 550E98B1-AE57-4857-845A-28C24CF101B8
// Assembly location: C:\Users\admin\.nuget\packages\respect.http\1.0.0\lib\net5.0\Respect.Http.dll

using System.Net.Http;

namespace Framework.Application
{
    public interface IHttpClientHelper
    {
        HttpClient Client { get; set; }
        TResponse Post<TData, TResponse>(
            string uri,
            TData data,
            string contentTypeDomainModel = null,
            string token = null);
        TResponse Put<TData, TResponse>(
            string uri,
            TData data,
            string contentTypeDomainModel = null,
            string token = null);
        TResponse Get<TData, TResponse>(string uri, string token, TData data);
        TResponse Get<TResponse>(string uri, string token = null);
        TResponse Delete<TData, TResponse>(
            string uri,
            TData data,
            string contentTypeDomainModel = null,
            string token = null);
    }
}