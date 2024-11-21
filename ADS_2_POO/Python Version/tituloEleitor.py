from documentos import Documentos
from documentosFormatacao import DocumentosFormatacao

class TituloEleitor(Documentos):
    def __init__(self, numero_input, tamanho_com_digitos, tamanho_sem_digitos):
        super().__init__(numero_input, tamanho_com_digitos, tamanho_sem_digitos)
        self.peso_um = [2, 3, 4, 5, 6, 7, 8, 9]
        self.peso_final = [7, 8, 9]
        self.numero = DocumentosFormatacao.formata_numero(numero_input, tamanho_com_digitos, tamanho_sem_digitos)
        self.numero_correto = (self.numero[:tamanho_sem_digitos] + self.calcular_digito(self.numero, self.peso_um))
        self.numero_correto = self.numero_correto + self.calcular_digito(
        self.numero_correto[self.tamanho_sem_digitos - 2:3], self.peso_final)
        self.mascara_numero = f"{self.numero_correto[:4]} {self.numero_correto[4:tamanho_sem_digitos - 2]} {self.numero_correto[tamanho_sem_digitos - 2:][:2]} {self.numero_correto[tamanho_com_digitos - 2:][:2]}"

    def calcular_digito(self, numero_input, pesos):
        soma = sum(int(numero_input[i]) * pesos[i] for i in range(min(len(numero_input), len(pesos))))
        resto = soma % 11

        digitos_dos_estados = numero_input[-2:]

        if digitos_dos_estados == "01" or digitos_dos_estados == "02":
            if resto == 0:
                return "1"  # Condição especial para SP e MG

        return '0' if resto > 9 else str(resto)

    def validar(self):
        resposta = f"{self.mascara_numero} {self.numero_correto} "

        if len(self.numero) == self.tamanho_com_digitos - 2:
            self.numero = self.numero + self.calcular_digito(self.numero, self.peso_um)

        if len(self.numero) == self.tamanho_com_digitos - 1:
            self.numero = self.numero + self.calcular_digito(self.numero[self.tamanho_sem_digitos - 2:3], self.peso_final)

        resposta = resposta + ("Valido" if self.numero_correto == self.numero else "Invalido")
        return resposta
