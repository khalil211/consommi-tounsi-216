using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace ConsommiTounsi.Utils
{
    public class HttpClientBuilder
    {
        public static HttpClient Get(object header = null)
        {
            HttpClient httpClient = 
                new HttpClient(new HttpClientHandler() 
                { 
                    UseCookies = false 
                });

            httpClient.BaseAddress = new Uri("http://localhost:8080/api/");

            httpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (header != null)
            {
                httpClient.DefaultRequestHeaders.Add("Cookie", (string)header);
            }
                
            return httpClient;
        }
    }
}