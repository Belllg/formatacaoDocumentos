from documentos import Documentos
from documentosFormatacao import DocumentosFormatacao

class InscricaoEstadual(Documentos):
    def __init__(self, numero_input):
        super().__init__(numero_input, 10, 8)
        self.peso_um = [3, 2, 7, 6, 5, 4, 3, 2]
        self.peso_final = [4, 3, 2, 7, 6, 5, 4, 3, 2]
        self.numero = DocumentosFormatacao.formata_numero(numero_input, self.tamanho_com_digitos, self.tamanho_sem_digitos)
        self.numero_correto = self.calcular_numero_correto(self.numero)
        self.mascara_numero = f"{self.numero_correto[:3]}.{self.numero_correto[3:8]}-{self.numero_correto[8:10]}"
