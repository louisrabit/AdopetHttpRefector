using System.Net.Http.Headers;
using System.Net.Http.Json;
using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Servicos
{
    public class HttpClientPet
    {
        private HttpClient client;


        //****2 

        //public HttpClientPet(string uri = "http://localhost:5057")
        //{
        //    client = ConfiguraHttpClient(uri);
        //}



        //  *** 2.1 -->  vamos criar um construtor do HttpClient ,   ao inves de poassar o Url , vou passar tb a intancia da HttpClient 
        // ele recebe um construtor HttpClient 
        public HttpClientPet(HttpClient client)
        {
            this.client = client;
        }




        //******2 --> conteudo que foi para HttpClientFactory -- > Conteudo do cliente 

        //HttpClient ConfiguraHttpClient(string url)
        //{

        //    // ****1
        //    // tem construçao de um objecto HttpClient 
        //    // Tipo de conecçao da Microsoft - HttpCleint --> representa uma conecçao Http entre client e server 
        //    // Esta construçao esta no comando import e list --> vamos otimizar a organizaçao entre client e server -- Esta no Import e List 
        //    HttpClient _client = new HttpClient();
        //    _client.DefaultRequestHeaders.Accept.Clear();
        //    _client.DefaultRequestHeaders.Accept.Add(
        //        new MediaTypeWithQualityHeaderValue("application/json"));
        //    _client.BaseAddress = new Uri(url);
        //    return _client;
        //}

        public Task CreatePetAsync(Pet pet)
        {
            return client.PostAsJsonAsync("pet/add", pet);
        }

        public async Task<IEnumerable<Pet>?> ListPetsAsync()
        {
            HttpResponseMessage response = await client.GetAsync("pet/list");
            return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
        }
    }
}
