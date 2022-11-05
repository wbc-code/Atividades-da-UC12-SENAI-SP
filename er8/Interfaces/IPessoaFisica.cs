using EncontroRemoto8.Enumeradores;

namespace EncontroRemoto8.Interfaces
{
    public interface IPessoaFisica
    {
        bool ValidarCPF();

        Maioridade VerificarMaioridade();
    }
}