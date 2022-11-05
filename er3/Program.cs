using EncontroRemoto3.Classes;

var pf1 = new PessoaFisica()
{
    Nome = "De menor",
    DataNascimento = new DateTime(2010,10,10)
};

var pf2 = new PessoaFisica()
{
    Nome = "Vanessa Ortega",
    DataNascimento = new DateTime(1980,10,18)
};

Console.WriteLine($"{pf1.Nome} é {pf1.ValidarDataNascimento()}");
Console.WriteLine($"{pf2.Nome} é {pf2.ValidarDataNascimento()}");