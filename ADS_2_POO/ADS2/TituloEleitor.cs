
public class TituloEleitor : Documentos
{

    public TituloEleitor(string numeroInput, int tamanhoComDigitos, int tamanhoSemDigitos) : base(numeroInput, tamanhoComDigitos, tamanhoSemDigitos)
    {
        pesoUm = new int[] { 2, 3, 4, 5, 6, 7, 8, 9 };
        pesoFinal = new int[] { 7, 8, 9 };
        numero = DocumentosFormatacao.FormataNumero(numero, tamanhoComDigitos, tamanhoSemDigitos);
        numeroCorreto = (numero[..tamanhoSemDigitos] + CalcularDigito(numero, pesoUm));
        numeroCorreto = numeroCorreto + CalcularDigito(numeroCorreto.Substring(tamanhoSemDigitos - 2, 3), pesoFinal); 

        mascaraNumero = numeroCorreto.Substring(0, 4) + " " + numeroCorreto.Substring(4, tamanhoSemDigitos - 6) + " " + numeroCorreto.Substring(tamanhoSemDigitos - 2, 2) + " " + numeroCorreto.Substring(tamanhoComDigitos - 2, 2);

    }

    public override string CalcularDigito(string numeroInput, int[] pesos)
    {
        int soma = 0;
        int length = Math.Min(numeroInput.Length, pesos.Length);//Por que pesos.Lenght - 1 n funcionou?

        for (int i = 0; i < length; i++)
        {
            soma += int.Parse(numeroInput[i].ToString()) * pesos[i];
        }

        int resto = soma % 11;

        resto = (resto > 9) ? 0 : resto;
        string digitosDosEstados = numero.Substring(tamanhoSemDigitos - 2, 2);

        if (digitosDosEstados == "01" || digitosDosEstados == "02")
        {
            if (resto == 0)
                return "1"; // Condição especial para SP e MG
        }
        
        return resto.ToString(); 
        
    }

    public override string Validar()
    {
        string resposta = mascaraNumero + " " + numeroCorreto + " ";
        if (numero.Length == tamanhoComDigitos - 2)
        {
            numero = (numero + CalcularDigito(numero, pesoUm));
        }

        if (numero.Length == tamanhoComDigitos - 1)
        {
            numero = numero + CalcularDigito(numero.Substring(tamanhoSemDigitos - 2, 3), pesoFinal);
        }

        resposta = resposta + ((numeroCorreto == numero) ? "Valido" : "Invalido");
        return resposta;
    }
}

