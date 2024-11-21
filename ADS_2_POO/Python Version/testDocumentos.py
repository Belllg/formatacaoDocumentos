import pytest
from documentosFormatacao import DocumentosFormatacao
from cnpj import CNPJ
from cpf import CPF
from pis import PIS
from tituloEleitor import TituloEleitor 
from inscricaoEstadual import InscricaoEstadual

class TestDocumentos:
    def test_LimparStringNumeroValido(self):
        assert DocumentosFormatacao.limpa_string("060cd.899.  480-47 ab", 11) == "06089948047"

    def test_LimparStringNumeroValidoSemLetras(self):
        assert DocumentosFormatacao.limpa_string("06089948047", 11) == "06089948047"

    def test_LimparStringNumeroInvalido(self):
        assert DocumentosFormatacao.limpa_string("060.899.480-471", 11) == "Numero Invalido"

    def test_PreencherZero(self):
        assert DocumentosFormatacao.preencher_numero("47", 11, 9) == "00000000047"

    def test_PreencherUmDigitoValidador(self):
        assert DocumentosFormatacao.preencher_numero("0608994804", 11, 9) == "0608994804"

    def test_PreencherDoisDigitosValidadores(self):
        assert DocumentosFormatacao.preencher_numero("06089948047", 11, 9) == "06089948047"

    def test_FormataNumeroLimpa(self):
        assert DocumentosFormatacao.formata_numero("060.899.480-47", 11, 9) == "06089948047"

    def test_FormataNumeroPreeche(self):
        assert DocumentosFormatacao.formata_numero("89948047", 11, 9) == "00089948047"

    def test_FormataNumeroLimpaPreeche(self):
        assert DocumentosFormatacao.formata_numero(".899.480-47", 11, 9) == "00089948047"

    ''' ====================='''

    def test_calcular_digito_resultado_maior_que_nove(self):
        cpf_exemplo = CPF("987654321")
        peso_um = [10, 9, 8, 7, 6, 5, 4, 3, 2]
        assert cpf_exemplo.calcular_digito("987654321", peso_um) == "0"

    def test_calcular_digito_resultado_menor_que_nove(self):
        cpf_valido = CPF("483.071.260-02")
        peso_dois = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2]
        assert cpf_valido.calcular_digito("48307126002", peso_dois) == "2"

    def test_calcular_numero_correto(self):
        cpf_valido = CPF("219.559.830-11")
        assert cpf_valido.calcular_numero_correto("219559830") == "21955983011"

    def test_cpf_valido_sem_pontos(self):
        cpf_valido = CPF("06089948047")
        resposta = "060.899.480-47" + " " + "06089948047" + " " + "Valido"
        assert cpf_valido.validar() == resposta

    def test_cpf_valido_faltando_numero_esquerda(self):
        cpf_valido = CPF("000.695.700-51")
        resposta = "000.695.700-51" + " " + "00069570051" + " " + "Valido"
        assert cpf_valido.validar() == resposta

    def test_cpf_valido_faltando_numero_direita(self):
        cpf_valido = CPF("060.899.480-4")
        resposta = "060.899.480-47" + " " + "06089948047" + " " + "Valido"
        assert cpf_valido.validar() == resposta

    def test_cpf_valido_faltando_dois_numero_direita_com_letras(self):
        cpf_valido = CPF("060.899.480-abx")
        resposta = "060.899.480-47" + " " + "06089948047" + " " + "Valido"
        assert cpf_valido.validar() == resposta

    def test_cpf_invalido(self):
        cpf_invalido = CPF("060.899.480-48")
        resposta = "060.899.480-47" + " " + "06089948047" + " " + "Invalido"
        assert cpf_invalido.validar() == resposta

    def test_pis_valido_sem_pontos(self):
        pis_valido = PIS("06282378200")
        resposta = "062.82378.20-0" + " " + "06282378200" + " " + "Valido"
        assert pis_valido.validar() == resposta

    def test_pis_valido_falta_numero_esquerda(self):
        pis_valido = PIS("82378.20-7")
        resposta = "000.82378.20-7" + " " + "00082378207" + " " + "Valido"
        assert pis_valido.validar() == resposta

    def test_pis_valido_falta_numero_direita(self):
        pis_valido = PIS("062.82378.20-")
        resposta = "062.82378.20-0" + " " + "06282378200" + " " + "Valido"
        assert pis_valido.validar() == resposta

    def test_pis_invalido(self):
        pis_invalido = PIS("062.82378.20-1")
        resposta = "062.82378.20-0" + " " + "06282378200" + " " + "Invalido"
        assert pis_invalido.validar() == resposta

    def test_cnpj_valido_sem_pontos(self):
        cnpj_valido = CNPJ("27096721000101")
        resposta = "27.096.721/0001-01" + " " + "27096721000101" + " " + "Valido"
        assert cnpj_valido.validar() == resposta

    def test_cnpj_valido_faltando_numero_esquerda(self):
        cnpj_valido = CNPJ("96.721/0001-47")
        resposta = "00.096.721/0001-47" + " " + "00096721000147" + " " + "Valido"
        assert cnpj_valido.validar() == resposta

    def test_cnpj_valido_faltando_numero_direita(self):
        cnpj_valido = CNPJ("2709672100010")
        resposta = "27.096.721/0001-01" + " " + "27096721000101" + " " + "Valido"
        assert cnpj_valido.validar() == resposta

    def test_cnpj_valido_faltando_dois_numero_direita_letras(self):
        cnpj_valido = CNPJ("270967210001adgsdgsd")
        resposta = "27.096.721/0001-01" + " " + "27096721000101" + " " + "Valido"
        assert cnpj_valido.validar() == resposta

    def test_cnpj_invalido(self):
        cnpj_invalido = CNPJ("27096721000150")
        resposta = "27.096.721/0001-01" + " " + "27096721000101" + " " + "Invalido"
        assert cnpj_invalido.validar() == resposta

    def test_titulo_eleitor_valido_sem_pontos(self):
        titulo_eleitor_valido = TituloEleitor("604425130590", 12, 10)
        resposta = "6044 2513 05 90" + " " + "604425130590" + " " + "Valido"
        assert titulo_eleitor_valido.validar() == resposta

    def test_titulo_eleitor_valido_faltando_numero_esquerda(self):
        titulo_eleitor_valido = TituloEleitor("0004 2513 05 31", 12, 10)
        resposta = "0004 2513 05 31" + " " + "000425130531" + " " + "Valido"
        assert titulo_eleitor_valido.validar() == resposta

    def test_titulo_eleitor_valido_faltando_numero_direita(self):
        titulo_eleitor_valido = TituloEleitor("6044 2513 05 9", 12, 10)
        resposta = "6044 2513 05 90" + " " + "604425130590" + " " + "Valido"
        assert titulo_eleitor_valido.validar() == resposta

    def test_titulo_eleitor_valido_faltando_dois_numero_direita_com_letras(self):
        titulo_eleitor_valido = TituloEleitor("6044 2513 05as", 12, 10)
        resposta = "6044 2513 05 90" + " " + "604425130590" + " " + "Valido"
        assert titulo_eleitor_valido.validar() == resposta

    def test_titulo_eleitor_invalido(self):
        titulo_eleitor_invalido = TituloEleitor("6044 2513 05 91", 12, 10)
        resposta = "6044 2513 05 90" + " " + "604425130590" + " " + "Invalido"
        assert titulo_eleitor_invalido.validar() == resposta

    def test_titulo_eleitor_sp(self):
        titulo_eleitor_valido = TituloEleitor("8264 1632 01 24", 12, 10)
        resposta = "8264 1632 01 24" + " " + "826416320124" + " " + "Valido"
        assert titulo_eleitor_valido.validar() == resposta

    def test_titulo_eleitor_sp_troca_zero(self):
        titulo_eleitor_valido = TituloEleitor("212228230141", 12, 10)
        resposta = "2122 2823 01 41" + " " + "212228230141" + " " + "Valido"
        assert titulo_eleitor_valido.validar() == resposta

    def test_titulo_eleitor_sp_digito_extra(self):
        titulo_eleitor_valido = TituloEleitor("2122282301449", 13, 11)
        resposta = "2122 28230 14 49" + " " + "2122282301449" + " " + "Valido"
        assert titulo_eleitor_valido.validar() == resposta

    def test_inscricao_estadual_sem_pontos(self):
        inscricao_estadual_valido = InscricaoEstadual("6113420128")
        resposta = "611.34201-28" + " " + "6113420128" + " " + "Valido"
        assert inscricao_estadual_valido.validar() == resposta

    def test_inscricao_estadual_valido_faltando_numero_esquerda(self):
        inscricao_estadual_valido = InscricaoEstadual(".34201-75")
        resposta = "000.34201-75" + " " + "0003420175" + " " + "Valido"
        assert inscricao_estadual_valido.validar() == resposta

    def test_inscricao_estadual_valido_faltando_numero_direita(self):
        inscricao_estadual_valido = InscricaoEstadual("611.34201-2")
        resposta = "611.34201-28" + " " + "6113420128" + " " + "Valido"
        assert inscricao_estadual_valido.validar() == resposta

    def test_inscricao_estadual_valido_faltando_dois_numero_direita_letras(self):
        inscricao_estadual_valido = InscricaoEstadual("611.34201-BOI")
        resposta = "611.34201-28" + " " + "6113420128" + " " + "Valido"
        assert inscricao_estadual_valido.validar() == resposta

    def test_inscricao_estadual_invalido(self):
        inscricao_estadual_invalido = InscricaoEstadual("6113420129")
        resposta = "611.34201-28" + " " + "6113420128" + " " + "Invalido"
        assert inscricao_estadual_invalido.validar() == resposta
