
public class CNPJ : Documentos
{

    public CNPJ(string numeroInput) : base(numeroInput, 14, 12)
    {
        pesoUm = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        pesoFinal = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        numero = DocumentosFormatacao.FormataNumero(numero, tamanhoComDigitos, tamanhoSemDigitos);
        numeroCorreto = CalcularNumeroCorreto(numero);
        mascaraNumero = numeroCorreto.Substring(0, 2) + "." + numeroCorreto.Substring(2, 3) + "." + numeroCorreto.Substring(5, 3) + "/" + numeroCorreto.Substring(8, 4) + "-" + numeroCorreto.Substring(12, 2);
    }

}