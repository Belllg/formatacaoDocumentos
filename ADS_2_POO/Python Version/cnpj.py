from documentosFormatacao import DocumentosFormatacao
from documentos import Documentos

class CNPJ(Documentos):
    def __init__(self, numero_input):
        super().__init__(numero_input, 14, 12)
        self.peso_um = [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2]
        self.peso_final = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2]
        self.numero = DocumentosFormatacao.formata_numero(numero_input, self.tamanho_com_digitos, self.tamanho_sem_digitos)
        self.numero_correto = self.calcular_numero_correto(self.numero)
        self.mascara_numero = f"{self.numero_correto[:2]}.{self.numero_correto[2:5]}.{self.numero_correto[5:8]}/{self.numero_correto[8:12]}-{self.numero_correto[12:]}"

# Se você não tiver uma classe DocumentosFormatacao e a função formata_numero, você precisará implementá-las ou adaptar o código conforme necessário.
