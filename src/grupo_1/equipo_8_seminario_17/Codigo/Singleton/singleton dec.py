# Usando decoradores
def singleton(cls):
    instance = None

    def getinstnce(*args, **kwargs):
        nonlocal instance
        if not instance:
            instance = cls(*args, **kwargs)
        return instance
    return getinstnce

#Prueba
@singleton
class Prueba:
    def __init__(self):  
        print("Yami")


#No se permite herencia porque el decorador convierte a Prueba en una funcion
#class Heredero(Prueba):
    #def __int__(self):
        #print("Holaaaaaa")


if __name__ == '__main__':
    a = Prueba()
    b = Prueba()
    print('a is b: ', a is b) #True

    #1er problema
    #Heredero NO se puede usar
    #c = Heredero()
    #print('c is a ', c is a)

    #2do problema
    #Singleton se puede evitar
    d = type(a)()
    print('d is a ', d is a) #False

    print('type(a): ', type(a)) #Es una clase
    print('Prueba: ', Prueba) #Es una funcion

    e = a
    print('e is a', e is a)

#Usar decoradores de esta forma, como funcion, no es
#la mejor opcion para solucionar nuestro priemer 
#problema. Puesto que no satisface la Herencia