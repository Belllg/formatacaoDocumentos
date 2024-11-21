
public class PIS : Documentos
{
    public PIS(string numeroInput) : base(numeroInput, 11, 10)
    {
        pesoFinal = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        numero = DocumentosFormatacao.FormataNumero(numero, tamanhoComDigitos, tamanhoSemDigitos);
        numeroCorreto = (numero[..(tamanhoSemDigitos)] + CalcularDigito(numero, pesoFinal));
        mascaraNumero = numeroCorreto.Substring(0, 3) + "." + numeroCorreto.Substring(3, 5) + "." + numeroCorreto.Substring(8, 2) + "-" + numeroCorreto.Substring(10, 1);
    }
}