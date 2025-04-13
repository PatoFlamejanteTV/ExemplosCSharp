using System;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Exemplo de Integração entre C# e IronPython");
        
        // Criar um motor Python
        ScriptEngine motor = Python.CreateEngine();
        
        // Executar código Python simples
        Console.WriteLine("\n1. Executando código Python simples:");
        motor.Execute("print('Olá do Python!')");
        
        // Definir variáveis no escopo do Python
        Console.WriteLine("\n2. Definindo e acessando variáveis:");
        ScriptScope escopo = motor.CreateScope();
        escopo.SetVariable("x", 42);
        escopo.SetVariable("mensagem", "Olá do C#!");
        
        motor.Execute("print(f'Python recebeu: x = {x}, mensagem = \"{mensagem}\"')", escopo);
        
        // Executar uma função Python e obter o resultado de volta no C#
        Console.WriteLine("\n3. Definindo e chamando uma função Python:");
        motor.Execute(@"
def calcular_soma(a, b):
    return a + b
", escopo);
        
        dynamic calcularSoma = escopo.GetVariable("calcular_soma");
        int resultado = calcularSoma(10, 20);
        Console.WriteLine($"Função Python retornou: {resultado}");
        
        // Trabalhando com listas Python
        Console.WriteLine("\n4. Trabalhando com listas Python:");
        motor.Execute(@"
minha_lista = [1, 2, 3, 4, 5]
def processar_lista(lst):
    return [item * 2 for item in lst]
", escopo);
        
        dynamic processarLista = escopo.GetVariable("processar_lista");
        dynamic minhaLista = escopo.GetVariable("minha_lista");
        dynamic listaProcessada = processarLista(minhaLista);
        
        Console.WriteLine("Lista original do Python: " + string.Join(", ", minhaLista));
        Console.WriteLine("Lista processada do Python: " + string.Join(", ", listaProcessada));
        
        Console.WriteLine("\nPressione qualquer tecla para sair...");
        Console.ReadKey();
    }
}