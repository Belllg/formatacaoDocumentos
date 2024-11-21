
public class InscricaoEstadual : Documentos
{

    public InscricaoEstadual(string numeroInput) : base(numeroInput, 10, 8)
    {
        pesoUm = new int[] { 3, 2, 7, 6, 5, 4, 3, 2 };
        pesoFinal = new int[] { 4, 3, 2, 7, 6, 5, 4, 3, 2 };
        numero = DocumentosFormatacao.FormataNumero(numero, tamanhoComDigitos, tamanhoSemDigitos);
        numeroCorreto = CalcularNumeroCorreto(numero);
        mascaraNumero = numeroCorreto.Substring(0, 3) + "." + numeroCorreto.Substring(3, 5) + "-" + numeroCorreto.Substring(8, 2);
    }

 
}
