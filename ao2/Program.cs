using AtividadeOnline2.Classes;
using AtividadeOnline2.Enumeradores;

var pf = new PessoaFisica()
{
    Nome = "João da Silva",
    DataNascimento = new DateTime(1980,1,1),
    CPF = "123.456.789-00"
};
pf.Enderecos.Add(new Endereco()
    {
        Tipo = TipoEndereco.Residencial,
        CEP = "01010-010",
        Logradouro = "Rua dos Testes", 
        Numero = "1",
        Complemento = "Apto. 1",
        Bairro = "Centro",
        Cidade = "São Paulo",
        UF = "SP"
    }
);

var arquivo = string.Concat(pf.Nome.Replace(" ", "-").ToLower(), ".txt");
var endereco = pf.Enderecos[0];

if (endereco.SemNumero)
{
    endereco.Numero = "S/N";
} 

using (var sw = new StreamWriter(arquivo))
{
    sw.WriteLine($"Nome: {pf.Nome}");
    sw.WriteLine($"Data de nascimento: {pf.DataNascimento.ToShortDateString()}");
    sw.WriteLine($"CPF: {pf.CPF}");
    sw.WriteLine($"Endereço {endereco.Tipo}");
    sw.WriteLine($"{endereco.Logradouro}, {endereco.Numero} {endereco.Complemento}");
    sw.WriteLine($"Bairro: {endereco.Bairro}");
    sw.WriteLine($"{endereco.CEP} - {endereco.Cidade}/{endereco.UF}");
    sw.Close();
}