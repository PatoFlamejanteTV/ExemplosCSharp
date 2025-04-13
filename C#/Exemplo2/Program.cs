// Método principal
Console.WriteLine("Obtendo o nome de usuário...");

// Obtém o nome de usuário do ambiente
string nomeUsuario = Environment.UserName;
//                   Environment SIGNIFICA O COMPUTADOR

// Exibe o nome de usuário
Console.WriteLine($"Nome de usuário do computador: {nomeUsuario}");

// Aguarda input do usuário antes de fechar
Console.WriteLine("\nPressione qualquer tecla para sair...");
Console.ReadKey(); // não fecha até apertar qualquer tecla.