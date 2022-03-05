// Decompiled with JetBrains decompiler
// Type: Respect.Http.HttpClientHelper
// Assembly: Respect.Http, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 550E98B1-AE57-4857-845A-28C24CF101B8
// Assembly location: C:\Users\admin\.nuget\packages\respect.http\1.0.0\lib\net5.0\Respect.Http.dll

using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Framework.Application
{
    public class HttpClientHelper : IHttpClientHelper
    {
        public HttpClient Client { get; set; }

        public HttpClientHelper()
        {
            this.Client = new HttpClient();
        }

        public TResponse Post<TData, TResponse>(
          string uri,
          TData data,
          string token = null,
          string contentTypeDomainModel = null)
        {
            return this.MakeRequest<TData, TResponse>(HttpMethod.Post, uri, data, token, contentTypeDomainModel, (string)null);
        }

        public TResponse Put<TData, TResponse>(
          string uri,
          TData data,
          string token = null,
          string contentTypeDomainModel = null)
        {
            return this.MakeRequest<TData, TResponse>(HttpMethod.Put, uri, data, token, contentTypeDomainModel, (string)null);
        }

        public TResponse Get<TData, TResponse>(string uri, string token, TData data)
        {
            return this.MakeRequest<TData, TResponse>(HttpMethod.Get, uri, token, data);
        }

        public TResponse Get<TResponse>(string uri, string token = null)
        {
            return this.MakeRequest<TResponse>(HttpMethod.Get, uri, token);
        }

        public TResponse Delete<TData, TResponse>(
          string uri,
          TData data,
          string token = null,
          string contentTypeDomainModel = null)
        {
            return this.MakeRequest<TData, TResponse>(HttpMethod.Delete, uri, data, token, (string)null, (string)null);
        }

        private TResponse MakeRequest<TData, TResponse>(
          HttpMethod method,
          string uri,
          TData data,
          string token = null,
          string accept = null,
          string contentTypeDomainModel = null)
        {
            HttpRequestMessage request = new HttpRequestMessage(method, uri);
            this.SetToken(token);
            return this.GetResponse<TResponse>(request);
        }

        private TResponse MakeRequest<TData, TResponse>(
          HttpMethod method,
          string uri,
          string token,
          TData data)
        {
            HttpRequestMessage request = (HttpRequestMessage)null;
            if ((object)data != null)
            {
                string content = JsonConvert.SerializeObject((object)data);
                request = new HttpRequestMessage()
                {
                    Method = method,
                    RequestUri = new Uri(uri),
                    Content = (HttpContent)new StringContent(content, Encoding.UTF8, "application/json")
                };
            }
            this.SetToken(token);
            return this.GetResponse<TResponse>(request);
        }

        private TResponse MakeRequest<TResponse>(HttpMethod method, string uri, string token = null)
        {
            HttpRequestMessage request = new HttpRequestMessage(method, uri);
            this.SetToken(token);
            return this.GetResponse<TResponse>(request);
        }

        private TResponse GetResponse<TResponse>(HttpRequestMessage request)
        {
            Task<HttpResponseMessage> task = this.Client.SendAsync(request);
            task.Wait();
            string result = task.Result.Content.ReadAsStringAsync().Result;
            if (task.Result.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<TResponse>(result);
            if (result != null && result.ToLower().Contains("code"))
            {
                ExceptionResponse exceptionResponse = JsonConvert.DeserializeObject<ExceptionResponse>(result);
                throw new Exception(string.Format("Error Getting Service From: {0} \n Error-Message: {1} \n Reason-Phrase:{2}", (object)request.RequestUri, (object)exceptionResponse.Message, (object)task.Result.ReasonPhrase));
            }
            throw new Exception(string.Format("Error Getting Service From: {0} \n Reason-Phrase:{1}", (object)request.RequestUri, (object)task.Result.ReasonPhrase));
        }

        private void SetToken(string token)
        {
            if (token == null)
                return;
            this.Client.SetBearerToken(token);
        }
    }
}
