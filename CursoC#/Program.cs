// Screen Sound
string msgBoasVindas = "\nBoas vindas ao Screen Sound";
//Criando uma lista de bandas, <tipagem>, nome da lista e instânciou a lista
//List<string> listaBandas = new List<string> { "Renascer Praise", "Central Praise", "Talles Roberto"};

//Declarar um discionario - Matriz
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Renascer Praise", new List<int> { 10, 8, 9, 0 });
bandasRegistradas.Add("Central Praise", new List<int>());
bandasRegistradas.Add("Talles Roberto", new List<int> { 9,5,10,9} );

void ExibirLogo()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");   
    Console.WriteLine(msgBoasVindas);
}
void ExibirOpMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opEscolhidaNum = int.Parse(opcaoEscolhida);

    switch (opEscolhidaNum)
    {
        case 1: RegistrarBanda();
            break;
        case 2: MostarBandasEgistradas();
            break;
        case 3: AvaliarBanda();
            break;
        case 4: ExibirMediaBanda();
            break;
        case -1: Console.WriteLine("Tchau tchau :)");
            break;
        default: Console.WriteLine("Opção inválida");
            break;

    }
}

void RegistrarBanda()
{
    //Limpa todo o consoles
    Console.Clear();
    ExibirTitulo("Registro de bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeBanda = Console.ReadLine()!;
    //Com o dicionario não faz sentido ter a lista de banda
    //listaBandas.Add(nomeBanda);
    //Então, agora iremos chamar o dicionário para obter os valores do lista e os valores.
    bandasRegistradas.Add(nomeBanda, new List<int>());
    //Interpolação de string {0}
    Console.WriteLine($"A banda {nomeBanda} foi registrada com sucesso!");
    //Função que aguarda 1000mile segundos
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpMenu();
}
void MostarBandasEgistradas()
{
    Console.Clear();
    ExibirTitulo("Exibindo todas as bandas registradas");
    //for(int i = 0; i < listaBandas.Count; i++)
    //{
    //    Console.WriteLine($"Banda: {listaBandas[i].ToString()}");
    //}

    foreach(string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpMenu();
}
ExibirOpMenu();

void ExibirTitulo(string titulo)
{
    int qtddLetras = titulo.Length;
    string asteristicos = string.Empty.PadLeft(qtddLetras, '*');//Colocar uma quantidade de algo numa string vazia na direita - função PadLeft ou PadRight para esquerda
    Console.WriteLine(asteristicos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteristicos + "\n");
}

void AvaliarBanda()
{
    //Limpando o console, para da a sensação que é uma janela nova
    Console.Clear();
    //Qual banda irá avaliar
    //Verificar se existe a banda no dicionario, se não volta ao menu principal
    //Atribuir uma nota
    ExibirTitulo("Avaliar banda");
    Console.Write("Digite o nme da banda que deseja avaliar:");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual a nota que a Banda merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso {nomeDaBanda}");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpMenu();
    } else { 
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal:");
        Console.ReadKey();
        Console.Clear();
        ExibirOpMenu();
    }

};

void ExibirMediaBanda() 
{
    Console.Clear();
    ExibirTitulo("Exibir Média da Banda");
    Console.WriteLine("\nQual o nome da banda deseja saber a média? ");
    string nomeBandaMedia = Console.ReadLine()!;
    if(bandasRegistradas.ContainsKey (nomeBandaMedia))
    {
        //Existe - Calculo da média
        if(bandasRegistradas[nomeBandaMedia].Count() > 1) { 
            var mediaBanda = bandasRegistradas[nomeBandaMedia].Sum() / bandasRegistradas[nomeBandaMedia].Count();
            Console.WriteLine($"(Modo Érica): A média da Banda {nomeBandaMedia} é de {mediaBanda}\n");

            //Estamos pegando todo os valores atribuidos a a banda 
            List<int> notaBanda = bandasRegistradas[nomeBandaMedia];
            //Existe um metodo que faz a média
            Console.WriteLine($"(Modo Gui) A média da Banda {nomeBandaMedia} é {notaBanda.Average()}.");
        }
        else
        {
            Console.WriteLine($"Banda {nomeBandaMedia} não possui nota.");
        }
        Console.WriteLine("Digite uma tecla para voltar ao menu principal:");
        Console.ReadKey();
        Console.Clear();
        ExibirOpMenu();
    } else
    {
        Console.WriteLine($"Banda {nomeBandaMedia} não cadastra!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal:");
        Console.ReadKey();
        Console.Clear();
        ExibirOpMenu();
    }
};

Console.WriteLine("***************************************************************************************");

Random aleatorio = new Random();
int numeroSecreto = aleatorio.Next(1, 11);

do
{
    Console.Write("Digite um número entre 1 e 10: ");
    int chute = int.Parse(Console.ReadLine()!);

    if (chute == numeroSecreto)
    { 
        Console.WriteLine("Parabéns! Você acertou o numero.");
        break;
    }else if(chute < numeroSecreto)
    {
        Console.WriteLine("O numero é maior.");
    }
    else
    {
        Console.WriteLine("O numero é menor.");
    }
} while (true);
Console.WriteLine("***************************************************************************************");