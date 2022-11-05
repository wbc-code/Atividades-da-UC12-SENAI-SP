using AtividadeOnline2.Enumeradores;

namespace AtividadeOnline2.Interfaces
{
    public interface IPessoaFisica
    {
        bool ValidarCPF();

        Maioridade ValidarDataNascimento();
    }
}