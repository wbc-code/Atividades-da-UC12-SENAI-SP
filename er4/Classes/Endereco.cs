using EncontroRemoto4.Enumeradores;

namespace EncontroRemoto4.Classes
{
    public sealed class Endereco
    {
        public TipoEndereco Tipo { get; set; }

        public string? CEP { get; set; }

        public string? Logradouro { get; set; }

        public string? Numero { get; set; }

        public bool SemNumero { get; set; }

        public string? Complemento { get; set; }

        public string? Bairro { get; set; }

        public string? Cidade { get; set; }

        public string? UF { get; set; }
    }
}