using System.Text.RegularExpressions;
using static DocumentosFormatacao;

public abstract class Documentos
{
    protected string numero;
    protected string numeroCorreto = "a";
    protected string mascaraNumero = "a";
    protected int[] pesoUm = { 0, 1 };
    protected int[] pesoFinal = { 0, 1};
    protected int tamanhoComDigitos;
    protected int tamanhoSemDigitos;
    

    public Documentos(string numero, int tamanhoComDigitos, int tamanhoSemDigitos)
    {
        this.numero = numero;
        this.tamanhoComDigitos = tamanhoComDigitos;
        this.tamanhoSemDigitos = tamanhoSemDigitos;
    }


    public virtual string CalcularDigito(string numero, int[] pesos)
    {
        int soma = 0;
        int length = Math.Min(numero.Length, pesos.Length);//Por que pesos.Lenght - 1 n funcionou?

        for (int i = 0; i < length; i++)
        {
            soma += int.Parse(numero[i].ToString()) * pesos[i];
        }

        int resto = soma % 11;
        int resultado = 11 - resto;
        return ((resultado > 9) ? 0 : resultado).ToString();

    }

    public string CalcularNumeroCorreto(string numero)  
    {
        numeroCorreto = (numero[..(tamanhoSemDigitos)] + CalcularDigito(numero, pesoUm));
        numeroCorreto = (numeroCorreto + CalcularDigito(numeroCorreto, pesoFinal));
        return numeroCorreto;
    }

    public virtual string Validar()
    {
       string resposta = mascaraNumero + " " + numeroCorreto + " ";
       if (numero.Length == tamanhoComDigitos - 2)
       {
            numero = (numero + CalcularDigito(numero, pesoUm));
       }

       if (numero.Length == tamanhoComDigitos - 1)
       {
            numero = (numero + CalcularDigito(numero, pesoFinal));
       }

        resposta = resposta + ((numeroCorreto == numero) ? "Valido" : "Invalido");
        return resposta;
    }
}
