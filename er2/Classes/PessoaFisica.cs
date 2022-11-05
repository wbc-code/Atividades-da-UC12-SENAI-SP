using EncontroRemoto2.Enumeradores;
using EncontroRemoto2.Interfaces;

namespace EncontroRemoto2.Classes
{
    public sealed class PessoaFisica: Pessoa, IPessoaFisica
    {
        public string? CPF { get; set; }

        public DateTime DataNascimento { get; set; }

        public override decimal PagarImposto(decimal rendimentos)
        {
            throw new NotImplementedException();
        }

        public bool ValidarCPF()
        {
            throw new NotImplementedException();
        }

        public Maioridade ValidarDataNascimento()
        {
            throw new NotImplementedException();
        }
    }
}