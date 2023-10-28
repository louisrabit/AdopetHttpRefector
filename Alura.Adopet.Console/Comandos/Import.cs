using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Comandos
{
    [DocComandoAttribute(instrucao: "import",
        documentacao: "adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets.")]
    internal class Import:IComando
    {
        // ****1
        //Vamos contruit objecto HttpClient 

        // ****1
        // vamops passar para o construtor o objecto Httpclient
        //vamos criar uma propriedade - vamos passar a instancia HttpCLient
        private readonly HttpClientPet httpClientPet;

        public Import(HttpClientPet httpClientPet)
        {
            this.httpClientPet = httpClientPet;
        }

        public async Task ExecutarAsync(string[] args)
        {
            await this.ImportacaoArquivoPetAsync(caminhoDoArquivoDeImportacao: args[1]);
        }

        private async Task ImportacaoArquivoPetAsync(string caminhoDoArquivoDeImportacao)
        {
            var leitor = new LeitorDeArquivo();
            List<Pet> listaDePet = leitor.RealizaLeitura(caminhoDoArquivoDeImportacao);
            foreach (var pet in listaDePet)
            {
                System.Console.WriteLine(pet);
                try
                {
                    // ****1
                    // Orinetaçao objecto --> estamos a criar uma instancia de um objecto 
                    // Tipo HttpclientPet
                    //var httpCreatePet = new HttpClientPet();
                    //await httpCreatePet.CreatePetAsync(pet);

                    await httpClientPet.CreatePetAsync(pet);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            System.Console.WriteLine("Importação concluída!");
        }
    }
}
