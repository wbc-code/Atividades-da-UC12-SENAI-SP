using EncontroRemoto2.Enumeradores;

namespace EncontroRemoto2.Interfaces
{
    public interface IPessoaFisica
    {
        bool ValidarCPF();

        Maioridade ValidarDataNascimento();
    }
}