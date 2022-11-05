using EncontroRemoto5.Classes;

var inicio = DateTime.Now;
var espera = 400;

Spin(" INÍCIO ", " Carregando programa, aguarde um momento", ConsoleColor.Magenta, espera);
ExibirBoasVindas(ConsoleColor.Green);
ExibirMenu(ConsoleColor.Green, espera);

var termino = DateTime.Now.Subtract(inicio);

Spin(" FINALIZANDO ", $" Obrigado por utilizar nosso sistema! Tempo de uso: { Math.Round(termino.TotalSeconds, 0) } segundos", ConsoleColor.Magenta, espera);

static void CadastrarPF(int espera)
{
    var pf = new PessoaFisica()
    {
        CPF = "123.456.789-0",
        DataNascimento = new DateTime(1980,10,18),
        Nome = "Vanessa Ortega"
    };

    Console.WriteLine();
    Console.WriteLine($"✓ Nome: { pf.Nome }");
    Thread.Sleep(espera);
    Console.WriteLine($"✓ Data de nascimento: { pf.DataNascimento.ToShortDateString() }");
    Thread.Sleep(espera);
    Console.WriteLine($"✓ Maior? { pf.ValidarDataNascimento() }");
    Thread.Sleep(espera);
    Console.WriteLine($"✓ CPF: { pf.CPF }");
    Thread.Sleep(espera);    
    Console.WriteLine();
}

static void CadastrarPJ(int espera)
{
    var pj = new PessoaJuridica()
    {
        CNPJ = "12.345.678/0001-99",
        RazaoSocial = "SimpleCode Serviços de Informática Ltda."        
    };

    Console.WriteLine();
    Console.WriteLine($"✓ Razão social: { pj.RazaoSocial }");
    Thread.Sleep(espera);
    Console.WriteLine($"✓ CNPJ: { pj.CNPJ }");
    Thread.Sleep(espera);
    Console.WriteLine($"✓ CNPJ válido? { pj.ValidarCNPJ() }");
    Thread.Sleep(espera);
    Console.WriteLine();
}

static void ExibirMenu(ConsoleColor cor, int espera)
{
    string? opcaoEscolhida;

    do
    {
        Console.WriteLine();
        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine();

        var opcoes = new Dictionary<int, string>()
        {
            {1, "Cadastrar pessoa física"},
            {2, "Cadastrar pessoa jurídica"}
        };

        foreach (var opcao in opcoes)
        {
            Console.ForegroundColor = cor;
            Console.Write($"    { opcao.Key }");

            Console.ResetColor();
            Console.WriteLine($" - { opcao.Value }");
        }

        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("    0 - Sair");

        Console.WriteLine();
        Console.Write("Informe sua opção: ");

        opcaoEscolhida = Console.ReadLine();

        switch (opcaoEscolhida)
        {
            case "1":
                CadastrarPF(espera);
                break;
            case "2":
                CadastrarPJ(espera);
                break;
        }

    } while (opcaoEscolhida != "0");
}

static void ExibirBoasVindas(ConsoleColor cor)
{
    Console.Clear();
    Console.ForegroundColor = cor;


    Console.WriteLine(@$"

  ____          _           _               ____  _____    ___     ____     ___ 
 / ___|__ _  __| | __ _ ___| |_ _ __ ___   |  _ \|  ___|  ( _ )    |  _ \   | |
| |   / _` |/ _` |/ _` / __| __| '__/ _ \  | |_) | |_     / _ \/\  | |_) |  | |
| |__| (_| | (_| | (_| \__ \ |_| | | (_) | |  __/|  _|   | (_>  <  |  __/ |_| |
 \____\__,_|\__,_|\__,_|___/\__|_|  \___/  |_|   |_|      \___/\/  |_|   \___/ 

    Bem-vindo ao sistema de cadastro de pessoa física e jurídica

                Rápido   -   fácil   -   seguro
");
    Console.ResetColor();
}

static void Spin(string titulo, string descricao, ConsoleColor cor, int espera)
{
    var counter = 0;
    Console.BackgroundColor = cor;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.Write(titulo);
    Console.ResetColor();
    Console.ForegroundColor = cor;
    Console.Write(descricao);
    do
    {
        switch (counter % 3)
        {
            case 0:
                Console.Write(".  ");
                break;
            case 1:
                Console.Write(" . ");
                break;
            case 2:
                Console.Write("  .");
                break;
        }
        Thread.Sleep(espera);
        Console.SetCursorPosition(Console.CursorLeft - 3, Console.CursorTop);
        counter++;

    } while (counter < 15);
    Console.ResetColor();
    Console.Clear();
}