using EncontroRemoto6.Enumeradores;

namespace EncontroRemoto6.Interfaces
{
    public interface IPessoaFisica
    {
        bool ValidarCPF();

        Maioridade ValidarDataNascimento();
    }
}