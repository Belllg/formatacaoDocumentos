from typing import List


class Documentos:
    def __init__(self, numero, tamanho_com_digitos, tamanho_sem_digitos):
        self.numero = numero
        self.tamanho_com_digitos = tamanho_com_digitos
        self.tamanho_sem_digitos = tamanho_sem_digitos
        self.numero_correto = "a"
        self.mascara_numero = "a"
        self.peso_um = [0, 1]
        self.peso_final = [0, 1]

    def calcular_digito(self, numero, pesos):
        soma = sum(int(numero[i]) * pesos[i] for i in range(min(len(numero), len(pesos))))
        resto = soma % 11
        resultado = 11 - resto
        return '0' if resultado > 9 else str(resultado)

    def calcular_numero_correto(self, numero):
        self.numero_correto = numero[:self.tamanho_sem_digitos] + self.calcular_digito(numero, self.peso_um)
        self.numero_correto = self.numero_correto + self.calcular_digito(self.numero_correto, self.peso_final)
        return self.numero_correto

    def validar(self):
        resposta = f"{self.mascara_numero} {self.numero_correto} "
        if len(self.numero) == self.tamanho_com_digitos - 2:
            self.numero = self.numero + self.calcular_digito(self.numero, self.peso_um)

        if len(self.numero) == self.tamanho_com_digitos - 1:
            self.numero = self.numero + self.calcular_digito(self.numero, self.peso_final)

        resposta = resposta + ("Valido" if self.numero_correto == self.numero else "Invalido")
        return resposta
