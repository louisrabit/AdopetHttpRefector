﻿using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Servicos;



// Vamos criar um novo objecto httpclientpet
// Estamos a compartilhar o mesmo objecto para os dois comandos 
var httpClientPet = new HttpClientPet();



Dictionary<string, IComando> comandosDoSistema = new()
{
    {"help",new Help() },
    {"import",new Import(httpClientPet)},
    {"list",new List(httpClientPet) },
    {"show",new Show() },
};

Console.ForegroundColor = ConsoleColor.Green;
try
{    
    string comando = args[0].Trim();
    if (comandosDoSistema.ContainsKey(comando))
    {
        IComando? cmd = comandosDoSistema[comando];
        await cmd.ExecutarAsync(args);
    }
    else
    {
        Console.WriteLine("Comando inválido!");
    } 
        
}
catch (Exception ex)
{
    // mostra a exceção em vermelho
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}