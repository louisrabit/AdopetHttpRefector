using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Servicos
{
  
    // ****2 
    // IHttpCLientFactory --> Interface que tem conteudo do HttpClient 
    public class HttpClientFactory : IHttpClientFactory
    {

        private string url = "http://localhost:5057";

        // Esta interface so tem um metodo CreateClient 
        public HttpClient CreateClient(string name)
        {
            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            _client.BaseAddress = new Uri(url);
            return _client;
        }
    }
}
