using EncontroRemoto3.Enumeradores;
using EncontroRemoto3.Interfaces;

namespace EncontroRemoto3.Classes
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
            var agora = DateTime.Now;
            var idade = agora.Subtract(this.DataNascimento);

            return idade.Days / 365 >= 18 ? Maioridade.Maior : Maioridade.Menor;            
        }
    }
}