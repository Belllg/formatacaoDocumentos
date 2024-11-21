import re
class DocumentosFormatacao:
    @staticmethod
    def formata_numero(numero, tamanho_com_digitos, tamanho_sem_digitos):
        numero = DocumentosFormatacao.limpa_string(numero, tamanho_com_digitos)
        numero = DocumentosFormatacao.preencher_numero(numero, tamanho_com_digitos, tamanho_sem_digitos)
        return numero

    @staticmethod
    def preencher_numero(numero, tamanho_com_digitos, tamanho_sem_digitos):
        if len(numero) >= tamanho_sem_digitos:
            return numero

        qtd_zeros = tamanho_com_digitos - len(numero)
        return '0' * qtd_zeros + numero

    @staticmethod
    def limpa_string(numero, tamanho_com_digitos):
        numero = re.sub(r'[^0-9]', '', numero).strip()
        if len(numero) <= tamanho_com_digitos:
            return numero
        return 'Numero Invalido'
