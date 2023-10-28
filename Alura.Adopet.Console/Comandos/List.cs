using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;

namespace Alura.Adopet.Console.Comandos
{
    [DocComandoAttribute(instrucao: "list",
      documentacao: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet.")]
    internal class List: IComando
    {
        // ****1
        //Vamos contruir objecto HttpClient 

        // ****1
        // vamops passar para o construtor o objecto Httpclient
        //vamos criar uma propriedade - vamos passar a instancia HttpCLient
        private readonly HttpClientPet httpClientPet;

        public List(HttpClientPet httpClientPet)
        {
            this.httpClientPet = httpClientPet;
        }
        public Task ExecutarAsync(string[] args)
        {
            return this.ListaDadosPetsDaAPIAsync();
        }

        private async Task ListaDadosPetsDaAPIAsync()
        {
            //var httpListPet = new HttpClientPet();
            //IEnumerable<Pet>? pets = await httpListPet.ListPetsAsync();
            //System.Console.WriteLine("----- Lista de Pets importados no sistema -----");

            // ****1
           IEnumerable<Pet>? pets = await httpClientPet.ListPetsAsync();
            System.Console.WriteLine("----- Lista de Pets importados no sistema -----");
            foreach (var pet in pets)
            {
                System.Console.WriteLine(pet);
            }
        }

    }
}
