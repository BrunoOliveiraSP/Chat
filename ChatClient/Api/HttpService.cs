using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Api
{
    class HttpService
    {
        public string Get(string uri)
        {
            HttpClient client = new HttpClient();
            string response = client.GetStringAsync(uri).Result;
            return response;
        }

        public string Post(string uri, string contentJson)
        {
            HttpClient client = new HttpClient();
            HttpContent content = new StringContent(contentJson, Encoding.UTF8, "application/json");

            string response = client.PostAsync(uri, content).Result
                                    .Content
                                    .ReadAsStringAsync().Result;
            return response;
        }

        public string Delete(string uri)
        {
            HttpClient client = new HttpClient();
            string response = client.DeleteAsync(uri).Result
                                    .Content
                                    .ReadAsStringAsync().Result;
            return response;
        }

        public string Update(string uri, string contentJson)
        {
            HttpClient client = new HttpClient();
            HttpContent content = new StringContent(contentJson, Encoding.UTF8, "application/json");

            string response = client.PutAsync(uri, content).Result
                                    .Content
                                    .ReadAsStringAsync().Result;
            return response;
        }
    }
}
