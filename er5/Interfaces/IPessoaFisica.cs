using EncontroRemoto5.Enumeradores;

namespace EncontroRemoto5.Interfaces
{
    public interface IPessoaFisica
    {
        bool ValidarCPF();

        Maioridade ValidarDataNascimento();
    }
}