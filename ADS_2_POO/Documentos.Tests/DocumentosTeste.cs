using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Documentos.Tests
{
    public class DocumentosTeste
    {
        /////////////////////LimpaString
        [Fact]
        public void LimparStringNumeroValido()
        {
            Assert.Equal("06089948047", DocumentosFormatacao.LimpaString("060cd.899.  480-47 ab", 11));
        }

        [Fact]
        public void LimparStringNumeroValidoSemLetras()
        {
            Assert.Equal("06089948047", DocumentosFormatacao.LimpaString("06089948047", 11));
        }

        [Fact]
        public void LimparStringNumeroInvalido()
        {
            Assert.Equal("Numero Invalido", DocumentosFormatacao.LimpaString("060.899.480-471", 11));
        }

        //////////////////////// PreencherNumero
        [Fact]
        public void PreencherZero()
        {
            Assert.Equal("00000000047", DocumentosFormatacao.PreencherNumero("47", 11, 9));
        }

        [Fact]
        public void PreencherUmDigitoValidador()
        {
            Assert.Equal("0608994804", DocumentosFormatacao.PreencherNumero("0608994804", 11, 9));
        }

        [Fact]
        public void PreencherDoisDigitosValidadores()
        {
            Assert.Equal("06089948047", DocumentosFormatacao.PreencherNumero("06089948047", 11, 9));
        }

        //Formata Numero
        [Fact]
        public void FormataNumeroLimpa()
        {
            Assert.Equal("06089948047", DocumentosFormatacao.FormataNumero("060.899.480-47", 11, 9));
        }

        [Fact]
        public void FormataNumeroPreeche()
        {
            Assert.Equal("00089948047", DocumentosFormatacao.FormataNumero("89948047", 11, 9));
        }

        [Fact]
        public void FormataNumeroLimpaPreeche()
        {
            Assert.Equal("00089948047", DocumentosFormatacao.FormataNumero(".899.480-47", 11, 9));
        }

        //  CPF/CalcularDigito

        [Fact]
        public void CalcularDigitoResultadoMaiorQueNove()
        {
            CPF cpfExemplo = new CPF("987654321");
            int[] pesoUm = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            Assert.Equal("0", cpfExemplo.CalcularDigito("987654321", pesoUm));
        }

        //  CPF/FormatarNumero/CalcularNumeroCorreto

        [Fact]
        public void CalcularDigitoResultadoMenorQueNove()
        {
            CPF cpfvalido = new CPF("483.071.260-02");
            int[] pesoDois = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            Assert.Equal("2", cpfvalido.CalcularDigito("48307126002", pesoDois));
        }

        //CalcularNumeroCorreto

        [Fact]
        public void CalcularNumeroCorreto()
        {
            CPF cpfValido = new CPF("219.559.830-11");
            Assert.Equal("21955983011", cpfValido.CalcularNumeroCorreto("219559830"));
        }

        /// //////////////////////////////////////////////////////////////////CPF
        [Fact]
        public void CPFValidoSemPontos()
        {
            CPF cpfValido = new CPF("06089948047");
            string resposta = "060.899.480-47" + " " + "06089948047" + " " + "Valido";
            Assert.Equal(resposta, cpfValido.Validar());
        }

        [Fact]
        public void CPFValidoFaltandoNumeroEsquerda()
        {
            CPF cpfValido = new CPF("000.695.700-51");
            string resposta = "000.695.700-51" + " " + "00069570051" + " " + "Valido";
            Assert.Equal(resposta, cpfValido.Validar());
        }

        [Fact]
        public void CPFValidoFaltandoNumeroDireita()
        {
            CPF cpfValido = new CPF("060.899.480-4");
            string resposta = "060.899.480-47" + " " + "06089948047" + " " + "Valido";
            Assert.Equal(resposta, cpfValido.Validar());
        }

        [Fact]
        public void CPFValidoFaltandoDoisNumeroDireitaComLetras()
        {
            CPF cpfValido = new CPF("060.899.480-abx");
            string resposta = "060.899.480-47" + " " + "06089948047" + " " + "Valido";
            Assert.Equal(resposta, cpfValido.Validar());
        }

        [Fact]
        public void CPFInvalido()
        {
            CPF cpfInvalido = new CPF("060.899.480-48");
            string resposta = "060.899.480-47" + " " + "06089948047" + " " + "Invalido"; 
            Assert.Equal(resposta, cpfInvalido.Validar());
        }


        ////////////PIS

        [Fact]
        public void PISValidoSemPontos()
        {
            PIS pisvalido = new PIS("06282378200");
            string resposta = "062.82378.20-0" + " " + "06282378200" + " " + "Valido";
            Assert.Equal(resposta, pisvalido.Validar());
        }
        
        [Fact]
        public void PISValidoFaltaNumeroEsquerda()
        {
            PIS pisvalido = new PIS("82378.20-7");
            string resposta = "000.82378.20-7" + " " + "00082378207" + " " + "Valido";
            Assert.Equal(resposta, pisvalido.Validar());
        }

        [Fact]
        public void PISValidoFaltaNumeroDireita()
        {
            PIS pisvalido = new PIS("062.82378.20-");
            string resposta = "062.82378.20-0" + " " + "06282378200" + " " + "Valido";
            Assert.Equal(resposta, pisvalido.Validar());
        }

        [Fact]
        public void PISInvalido()
        {
            PIS pisvalido = new PIS("062.82378.20-1");
            string resposta = "062.82378.20-0" + " " + "06282378200" + " " + "Invalido";
            Assert.Equal(resposta, pisvalido.Validar());
        }

        ////////CNPJ
        ///

        [Fact]
        public void CNPJValidoSemPontos()
        {
            CNPJ cnpjvalido = new CNPJ("27096721000101");
            string resposta = "27.096.721/0001-01" + " " + "27096721000101" + " " + "Valido";
            Assert.Equal(resposta, cnpjvalido.Validar());
        }

        [Fact]
        public void CNPJValidoFaltandoNumeroEsquerda()
        {
            CNPJ cnpjvalido = new CNPJ("96.721/0001-47");
            string resposta = "00.096.721/0001-47" + " " + "00096721000147" + " " + "Valido";
            Assert.Equal(resposta, cnpjvalido.Validar());
        }

        [Fact]
        public void CNPJValidoFaltandoNumeroDireita()
        {
            CNPJ cnpjvalido = new CNPJ("2709672100010");
            string resposta = "27.096.721/0001-01" + " " + "27096721000101" + " " + "Valido";
            Assert.Equal(resposta, cnpjvalido.Validar());
        }

        [Fact]
        public void CNPJValidoFaltandoDoisNumeroDireitaLetras()
        {
            CNPJ cnpjvalido = new CNPJ("270967210001adgsdgsd");
            string resposta = "27.096.721/0001-01" + " " + "27096721000101" + " " + "Valido";
            Assert.Equal(resposta, cnpjvalido.Validar());
        }

        [Fact]
        public void CNPJInvalido()
        {
            CNPJ cnpjvalido = new CNPJ("27096721000150");
            string resposta = "27.096.721/0001-01" + " " + "27096721000101" + " " + "Invalido";
            Assert.Equal(resposta, cnpjvalido.Validar());
        }


        ////Titulo de eleitor


        [Fact]
        public void TituloEleitorValidoSemPontos()
        {
            TituloEleitor TituloEleitorValido = new TituloEleitor("604425130590", 12, 10);
            string resposta = "6044 2513 05 90" + " " + "604425130590" + " " + "Valido";
            Assert.Equal(resposta, TituloEleitorValido.Validar());
        }
        
        [Fact]
        public void TituloEleitorValidoFaltandoNumeroEsquerda()
        {
            TituloEleitor TituloEleitorValido = new TituloEleitor("0004 2513 05 31", 12, 10);
            string resposta = "0004 2513 05 31" + " " + "000425130531" + " " + "Valido";
            Assert.Equal(resposta, TituloEleitorValido.Validar());
        }

        [Fact]
        public void TituloEleitorValidoFaltandoNumeroDireita()
        {
            TituloEleitor TituloEleitorValido = new TituloEleitor("6044 2513 05 9", 12, 10);
            string resposta = "6044 2513 05 90" + " " + "604425130590" + " " + "Valido";
            Assert.Equal(resposta, TituloEleitorValido.Validar());
        }

        [Fact]
        public void TituloEleitorValidoFaltandoDoisNumeroDireitaComLetras()
        {
            TituloEleitor TituloEleitorValido = new TituloEleitor("6044 2513 05as", 12, 10);
            string resposta = "6044 2513 05 90" + " " + "604425130590" + " " + "Valido";
            Assert.Equal(resposta, TituloEleitorValido.Validar());
        }

        [Fact]
        public void TituloEleitorInvalido()
        {
            TituloEleitor TituloelEitorInvalido = new TituloEleitor("6044 2513 05 91", 12, 10);
            string resposta = "6044 2513 05 90" + " " + "604425130590" + " " + "Invalido";
            Assert.Equal(resposta, TituloelEitorInvalido.Validar()); 
        }

        [Fact]
        public void TituloEleitorSP()
        {
            TituloEleitor tituloEleitorvalido = new TituloEleitor("8264 1632 01 24", 12, 10);
            string resposta = "8264 1632 01 24" + " " + "826416320124" + " " + "Valido";
            Assert.Equal(resposta, tituloEleitorvalido.Validar());
        }

        [Fact]
        public void TituloEleitorSPTrocaZero()
        {
            TituloEleitor tituloEleitorvalido = new TituloEleitor("212228230141", 12, 10);
            string resposta = "2122 2823 01 41" + " " + "212228230141" + " " + "Valido";
            Assert.Equal(resposta, tituloEleitorvalido.Validar());
        }

        [Fact]
        public void TituloEleitorSPDigitoExtra()
        {
            TituloEleitor tituloEleitorvalido = new TituloEleitor("2122282301449", 13, 11);
            string resposta = "2122 28230 14 49" + " " + "2122282301449" + " " + "Valido";
            Assert.Equal(resposta, tituloEleitorvalido.Validar());
        }

        //InscricaoEstadual

        [Fact]
        public void InscricaoEstadualSemPontos()
        {
            InscricaoEstadual inscricaoEstadualValido = new InscricaoEstadual("6113420128");
            string resposta = "611.34201-28" + " " + "6113420128" + " " + "Valido";
            Assert.Equal(resposta, inscricaoEstadualValido.Validar());
        }
        
        [Fact]
        public void InscricaoEstadualValidoFaltandoNumeroEsquerda()
        {
            InscricaoEstadual inscricaoEstadualValido = new InscricaoEstadual(".34201-75");
            string resposta = "000.34201-75" + " " + "0003420175" + " " + "Valido";
            Assert.Equal(resposta, inscricaoEstadualValido.Validar());
        }

        [Fact]
        public void InscricaoEstadualValidoFaltandoNumeroDireita()
        {
            InscricaoEstadual inscricaoEstadualValido = new InscricaoEstadual("611.34201-2");
            string resposta = "611.34201-28" + " " + "6113420128" + " " + "Valido";
            Assert.Equal(resposta, inscricaoEstadualValido.Validar());
        }

        [Fact]
        public void InscricaoEstadualValidoFaltandoDoisNumeroDireitaLetras()
        {
            InscricaoEstadual inscricaoEstadualValido = new InscricaoEstadual("611.34201-BOI");
            string resposta = "611.34201-28" + " " + "6113420128" + " " + "Valido";
            Assert.Equal(resposta, inscricaoEstadualValido.Validar());
        }

        [Fact]
        public void InscricaoEstadualInvalido()
        {
            InscricaoEstadual inscricaoEstadualValido = new InscricaoEstadual("6113420129");
            string resposta = "611.34201-28" + " " + "6113420128" + " " + "Invalido";
            Assert.Equal(resposta, inscricaoEstadualValido.Validar());
        }
    }
}
    