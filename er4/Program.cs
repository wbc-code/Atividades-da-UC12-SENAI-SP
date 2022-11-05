using EncontroRemoto4.Classes;

var pj1 = new PessoaJuridica() 
{
    RazaoSocial = "SimpleCode Serviços de Informática Ltda.",
    CNPJ = "10.482.912/0001-09"
};

var pj2 = new PessoaJuridica()
{
    RazaoSocial = "Empresa de Mentirinha",
    CNPJ = "12.345.678/0001-09"
};

Console.WriteLine($"O CNPJ de { pj1.RazaoSocial } é { pj1.ValidarCNPJ() }");
Console.WriteLine($"O CNPJ de { pj2.RazaoSocial } é { pj2.ValidarCNPJ() }");