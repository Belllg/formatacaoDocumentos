from documentos import Documentos
from documentosFormatacao import DocumentosFormatacao

class PIS(Documentos):
    def __init__(self, numero_input):
        super().__init__(numero_input, 11, 10)
        self.peso_final = [3, 2, 9, 8, 7, 6, 5, 4, 3, 2]
        self.numero = DocumentosFormatacao.formata_numero(numero_input, self.tamanho_com_digitos, self.tamanho_sem_digitos)
        self.numero_correto = self.numero[:self.tamanho_sem_digitos] + self.calcular_digito(self.numero, self.peso_final)
        self.mascara_numero = f"{self.numero_correto[:3]}.{self.numero_correto[3:8]}.{self.numero_correto[8:10]}-{self.numero_correto[10]}"
