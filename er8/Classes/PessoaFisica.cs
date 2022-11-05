using EncontroRemoto8.Enumeradores;
using EncontroRemoto8.Interfaces;

namespace EncontroRemoto8.Classes
{
    public sealed class PessoaFisica: Pessoa, IPessoaFisica
    {
        public string? CPF { get; set; }

        public DateTime DataNascimento { get; set; }

        public override decimal PagarImposto()
        {
            decimal imposto;

            if (Rendimento <= 1500)
            {
                imposto = 0;
            }
            else if (Rendimento > 1500 && Rendimento <= 3500)
            {
                imposto = Rendimento * .02M;
            }
            else if (Rendimento > 3500 && Rendimento <= 6000)
            {
                imposto = Rendimento * .035M;
            }
            else
            {
                imposto = Rendimento * .05M;
            }

            return imposto;
        }

        public bool ValidarCPF()
        {
            throw new NotImplementedException();
        }

        public Maioridade VerificarMaioridade()
        {            
            var agora = DateTime.Now;
            var idade = agora.Subtract(this.DataNascimento);

            return idade.Days / 365 >= 18 ? Maioridade.Maior : Maioridade.Menor;            
        }
    }
}