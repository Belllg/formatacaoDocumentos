using System.Text.RegularExpressions;

public static class DocumentosFormatacao
{
    public static string FormataNumero(string numero, int tamanhoComDigitos, int tamanhoSemDigitos)
    {
        numero = LimpaString(numero, tamanhoComDigitos);
        numero = PreencherNumero(numero, tamanhoComDigitos, tamanhoSemDigitos);

        return numero;
    }

    public static string PreencherNumero(string numero, int tamanhoComDigitos, int tamanhoSemDigitos)
    {
        if (numero.Length >= tamanhoSemDigitos)
        {
            return numero;
        }

        int qtdZeros = tamanhoComDigitos - numero.Length;
        
        return new string('0', qtdZeros) + numero; ;
    }

    public static string LimpaString(string numero, int tamanhoComDigitos)
    {
        numero = Regex.Replace(numero, "[^0-9]", "").Trim();
        if (numero.Length <= tamanhoComDigitos)
        {
            return numero;
        }
        return "Numero Invalido";
    }

}



