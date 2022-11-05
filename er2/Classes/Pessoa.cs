namespace EncontroRemoto2.Classes
{
    public abstract class Pessoa
    {
        public Pessoa()
        {
            Enderecos = new List<Endereco>();
        }

        public string? Nome { get; set; }

        public IList<Endereco> Enderecos { get; set; }

        public abstract decimal PagarImposto(decimal rendimentos);
    
    }
}