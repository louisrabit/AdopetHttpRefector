using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Testes;

public class importTest
{
    [Fact]
    public async void Teste01()
    {
        //Arrange 
        var httpClientPet = new HttpClientPet(new HttpClientFactory().CreateClient("adopet"));
        var import = new Import(httpClientPet);
        string[] args = { "import", "lista.csv" };

        //Act
        await import.ExecutarAsync(args);

        //Assert
        var listaPwt = await httpClientPet.ListPetsAsync();
        Assert.NotNull(listaPwt);
    }


}
