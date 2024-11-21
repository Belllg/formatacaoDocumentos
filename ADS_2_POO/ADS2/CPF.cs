
public class CPF : Documentos
{

    public CPF(string numeroInput) : base(numeroInput, 11, 9)
    {
        pesoUm = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        pesoFinal = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        numero = DocumentosFormatacao.FormataNumero(numero, tamanhoComDigitos, tamanhoSemDigitos);
        numeroCorreto = CalcularNumeroCorreto(numero);
        mascaraNumero = numeroCorreto.Substring(0, 3) + "." + numeroCorreto.Substring(3, 3) + "." + numeroCorreto.Substring(6, 3) + "-" + numeroCorreto.Substring(9, 2);
    }

  
}
