using EncontroRemoto7.Enumeradores;

namespace EncontroRemoto7.Interfaces
{
    public interface IPessoaFisica
    {
        bool ValidarCPF();

        Maioridade VerificarMaioridade();
    }
}