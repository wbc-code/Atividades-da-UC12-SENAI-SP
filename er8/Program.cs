using EncontroRemoto8.Classes;

var inicio = DateTime.Now;
var espera = 400;
var pfs = new List<PessoaFisica>();
var pjs = new List<PessoaJuridica>();

Spin(" INÍCIO ", " Carregando programa, aguarde um momento", ConsoleColor.Magenta, espera);
ExibirBoasVindas(ConsoleColor.Green);
ExibirMenu(ConsoleColor.Green, espera, pfs, pjs);

var termino = DateTime.Now.Subtract(inicio);

Spin(" FINALIZANDO ", $" Obrigado por utilizar nosso sistema! Tempo de uso: { Math.Round(termino.TotalSeconds, 0) } segundos", ConsoleColor.Magenta, espera);

static void CadastrarPF(ConsoleColor cor, IList<PessoaFisica> pfs)
{
    var pf = new PessoaFisica();
    var endereco = new Endereco();

    Console.WriteLine("~ Informe os dados a seguir para cadastrar nova pessoa física ~");
    Console.WriteLine();

    Console.Write("Nome completo: ");
    pf.Nome = Console.ReadLine();
    while (string.IsNullOrEmpty(pf.Nome))
    {
        Console.Write("Nome não pode ser vazio. Informe o nome completo: ");
        pf.Nome = Console.ReadLine();
    }

    Console.Write("Data de nascimento: ");
    DateTime nascimento;
    DateTime.TryParse(Console.ReadLine(), out nascimento);
    while (nascimento <= DateTime.MinValue || nascimento > DateTime.Now.Date)
    {
        Console.Write("Data inválida. Informe a data de nascimento: ");
        DateTime.TryParse(Console.ReadLine(), out nascimento);
    }
    pf.DataNascimento = nascimento;

    Console.Write("CPF: ");
    pf.CPF = Console.ReadLine();

    Console.Write("Rendimento mensal: ");
    decimal rendimento;
    decimal.TryParse(Console.ReadLine(), out rendimento);
    if (rendimento < 0) rendimento = 0;
    pf.Rendimento = rendimento;

    Console.Write("Logradouro: ");
    endereco.Logradouro = Console.ReadLine();

    Console.Write("Número: ");
    endereco.Numero = Console.ReadLine();

    Console.Write("Complemento: ");
    endereco.Complemento = Console.ReadLine();

    Console.Write("Bairro: ");
    endereco.Bairro = Console.ReadLine();

    Console.Write("Cidade: ");
    endereco.Cidade = Console.ReadLine();

    Console.Write("UF: ");
    endereco.UF = Console.ReadLine();

    Console.Write("CEP: ");
    endereco.CEP = Console.ReadLine();

    pf.Enderecos.Add(endereco);
    pfs.Add(pf);

    using (var sw = File.AppendText("PessoaFisica.csv"))
    {
        sw.WriteLine($"{ pf.Nome }, { pf.CPF }, { pf.DataNascimento }");
        sw.Close();
    }

    Console.ForegroundColor = cor;
    Console.WriteLine();
    Console.WriteLine("~ Cadastro efetuado com sucesso! ~");
    Console.WriteLine();
    Console.ResetColor();
}

static void ListarPFs(int espera, ConsoleColor cor, IList<PessoaFisica> pfs)
{
    if (pfs.Count <= 0)
    {
        Console.WriteLine("Nenhuma pessoa física cadastrada.");
        Console.WriteLine();
    }

    foreach (var pf in pfs)
    {
        var endereco = pf.Enderecos[0];

        Console.ForegroundColor = cor;
        Console.WriteLine($"✓ Nome: { pf.Nome }");
        Console.ResetColor();
        Console.WriteLine($"✓ Data de nascimento: { pf.DataNascimento.ToShortDateString() }");        
        Console.WriteLine($"✓ Maior? { pf.VerificarMaioridade() }");        
        Console.WriteLine($"✓ CPF: { pf.CPF }");        
        Console.WriteLine($"✓ Imposto a pagar: { pf.PagarImposto().ToString("C") }");
        Console.WriteLine($"✓ Endereço: { endereco.Logradouro }, { endereco.Numero } - { endereco.Complemento }");
        Console.WriteLine($"✓ Cidade/UF: { endereco.Cidade }/{ endereco.UF }");
        Console.WriteLine();
        Thread.Sleep(espera);
    }
}

static void CadastrarPJ(ConsoleColor cor, IList<PessoaJuridica> pjs)
{
    var pj = new PessoaJuridica();
    var endereco = new Endereco();

    Console.WriteLine("~ Informe os dados a seguir para cadastrar nova pessoa jurídica ~");
    Console.WriteLine();

    Console.Write("Razão Social: ");
    pj.RazaoSocial = Console.ReadLine();
    while (string.IsNullOrEmpty(pj.RazaoSocial))
    {
        Console.Write("Razão Social não pode ser vazia. Informe a Razão Social: ");
        pj.RazaoSocial = Console.ReadLine();
    }

    Console.Write("CNPJ: ");
    pj.CNPJ = Console.ReadLine();

    Console.Write("Rendimento mensal: ");
    decimal rendimento;
    decimal.TryParse(Console.ReadLine(), out rendimento);
    if (rendimento < 0) rendimento = 0;
    pj.Rendimento = rendimento;

    Console.Write("Logradouro: ");
    endereco.Logradouro = Console.ReadLine();

    Console.Write("Número: ");
    endereco.Numero = Console.ReadLine();

    Console.Write("Complemento: ");
    endereco.Complemento = Console.ReadLine();

    Console.Write("Bairro: ");
    endereco.Bairro = Console.ReadLine();

    Console.Write("Cidade: ");
    endereco.Cidade = Console.ReadLine();

    Console.Write("UF: ");
    endereco.UF = Console.ReadLine();

    Console.Write("CEP: ");
    endereco.CEP = Console.ReadLine();

    pj.Enderecos.Add(endereco);
    pjs.Add(pj);

    using (var sw = File.AppendText("PessoaJuridica.csv"))
    {
        sw.WriteLine($"{ pj.RazaoSocial }, { pj.CNPJ }");
        sw.Close();
    }

    Console.ForegroundColor = cor;
    Console.WriteLine();
    Console.WriteLine("~ Cadastro efetuado com sucesso! ~");
    Console.WriteLine();
    Console.ResetColor();
}

static void ListarPJs(int espera, ConsoleColor cor, IList<PessoaJuridica> pjs)
{
    if (pjs.Count <= 0)
    {
        Console.WriteLine("Nenhuma pessoa jurídica cadastrada.");
        Console.WriteLine();
    }

    foreach (var pj in pjs)
    {
        var endereco = pj.Enderecos[0];

        Console.ForegroundColor = cor;
        Console.WriteLine($"✓ Razão Social: { pj.RazaoSocial }");
        Console.ResetColor();
        Console.WriteLine($"✓ CNPJ: { pj.CNPJ }");
        Console.WriteLine($"✓ CNPJ válido? { pj.ValidarCNPJ() }");        
        Console.WriteLine($"✓ Imposto a pagar: { pj.PagarImposto().ToString("C") }");
        Console.WriteLine($"✓ Endereço: { endereco.Logradouro }, { endereco.Numero } - { endereco.Complemento }");
        Console.WriteLine($"✓ Cidade/UF: { endereco.Cidade }/{ endereco.UF }");
        Console.WriteLine();
        Thread.Sleep(espera);
    }
}

static void ExibirMenu(ConsoleColor cor, int espera, IList<PessoaFisica> pfs, IList<PessoaJuridica> pjs)
{
    string? opcaoEscolhida;

    do
    {
        Console.WriteLine();
        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine();

        var opcoes = new Dictionary<int, string>()
        {
            {1, "Cadastrar pessoa física" },
            {2, "Exibir PFs cadastradas" },
            {3, "Cadastrar pessoa jurídica" },
            {4, "Exibir PJs cadastradas" }
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
                CadastrarPF(cor, pfs);
                break;
            case "2":
                ListarPFs(espera, cor, pfs);
                break;
            case "3":
                CadastrarPJ(cor, pjs);
                break;
            case "4":
                ListarPJs(espera, cor, pjs);
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