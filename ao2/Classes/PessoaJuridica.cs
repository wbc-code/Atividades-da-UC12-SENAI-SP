using AtividadeOnline2.Enumeradores;
using AtividadeOnline2.Interfaces;

namespace AtividadeOnline2.Classes
{
    public sealed class PessoaJuridica : Pessoa, IPessoaJuridica
    {
        public string? CNPJ { get; set; }

        public string? RazaoSocial { get; set; }

        public override decimal PagarImposto(decimal rendimentos)
        {
            throw new NotImplementedException();
        }

        public bool ValidarCNPJ()
        {
            throw new NotImplementedException();
        }
    }
}