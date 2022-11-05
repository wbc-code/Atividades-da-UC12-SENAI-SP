using EncontroRemoto6.Enumeradores;
using EncontroRemoto6.Interfaces;

namespace EncontroRemoto6.Classes
{
    public sealed class PessoaJuridica: Pessoa, IPessoaJuridica
    {
        public string? CNPJ { get; set; }

        public string? RazaoSocial { get; set; }

        public override decimal PagarImposto()
        {
            decimal imposto;

            if (Rendimento <= 3000)
            {
                imposto = Rendimento * .03M;
            }
            else if (Rendimento > 3000 && Rendimento <= 6000)
            {
                imposto = Rendimento * .05M;
            }
            else if (Rendimento > 6000 && Rendimento <= 10000)
            {
                imposto = Rendimento * .07M;
            }
            else
            {
                imposto = Rendimento * .09M;
            }

            return imposto;
        }

        public bool ValidarCNPJ()
        {
            if (this.CNPJ == null)
                return false;

            var multiplicador1 = new int[12] {5,4,3,2,9,8,7,6,5,4,3,2};
			var multiplicador2 = new int[13] {6,5,4,3,2,9,8,7,6,5,4,3,2};
			int soma;
			int resto;
			string digito;
			string tempCnpj;
			
            var cnpj = this.CNPJ.Trim();
			cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
			
            if (cnpj.Length != 14)
			   return false;
			
            tempCnpj = cnpj.Substring(0, 12);
			soma = 0;
			for(int i=0; i<12; i++)
			   soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
			resto = (soma % 11);
			
            if ( resto < 2)
			   resto = 0;
			else
			   resto = 11 - resto;
			
            digito = resto.ToString();
			tempCnpj = tempCnpj + digito;
			soma = 0;
			
            for (int i = 0; i < 13; i++)
			   soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
			
            resto = (soma % 11);
			
            if (resto < 2)
			    resto = 0;
			else
			   resto = 11 - resto;
			
            digito = digito + resto.ToString();
			
            return cnpj.EndsWith(digito);
        }
    }
}