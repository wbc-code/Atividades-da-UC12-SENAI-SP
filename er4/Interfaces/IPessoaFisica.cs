using EncontroRemoto4.Enumeradores;

namespace EncontroRemoto4.Interfaces
{
    public interface IPessoaFisica
    {
        bool ValidarCPF();

        Maioridade ValidarDataNascimento();
    }
}