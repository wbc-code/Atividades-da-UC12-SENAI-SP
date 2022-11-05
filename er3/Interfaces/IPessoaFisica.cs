using EncontroRemoto3.Enumeradores;

namespace EncontroRemoto3.Interfaces
{
    public interface IPessoaFisica
    {
        bool ValidarCPF();

        Maioridade ValidarDataNascimento();
    }
}