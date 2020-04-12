class Pato:
    def quack(self):
        print('Quack')
    def camina(self):
        print('Camina como pato')

class Persona:
    def quack(self):
        print("Imita el sonido de un pato")
    def camina(self):
        print("Camina encorvado con las manos en la espalda")

def pati_rutina(pato):
    pato.quack()
    pato.camina()

Donald = Pato()
Donald_Trump = Persona()

pati_rutina(Donald)
pati_rutina(Donald_Trump)