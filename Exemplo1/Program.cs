// See https://aka.ms/new-console-template for more information

// Pergunta o nome do usuário
Console.Write("Insira seu nome: ");

// Lê o que o usuário digitar depois da pergunta
string? name = Console.ReadLine();

// Exibe "Olá! [nome]!"
Console.WriteLine($"Olá! {name}!");