class Singleton(type):
    def __init__(cls, *args, **kwargs):
        print("Entro al llamado __init__()") #Entra por cada clase 1 vez
        cls.instance = None
        super(Singleton, cls).__init__(*args, **kwargs)
    
    def __call__(cls, *args, **kwargs):
        print("Entro al llamado __call__()")
        if not cls.instance:
            cls.instance = super(Singleton, cls).__call__(*args, **kwargs)
        return cls.instance



class Prueba(metaclass=Singleton):
    def __init__(self):
        print(" ")

class Heredero(Prueba):
    def __init__(self):
        print("Hello again")

class OtraPrueba:
    def __new__(cls, *args, **kwargs):
        return object.__new__(cls)

class Otra(OtraPrueba, Prueba):
    def __init__(self):
        print("another Hello ")


if __name__ == '__main__':
    #print("Imprimiendo Pureba.__dic__ antes de crear instancias: ")
    #print('Prueba.__dict__: ', Prueba.__dict__)
    a = Prueba() #Entro al llamado __call__() 
    #print("Imprimiendo Pureba.__dic__ despues de crear la instancia a: ")
    #print('Prueba.__dict__: ', Prueba.__dict__)
    #print(" ")
    
    b = Prueba() #Entro al llamado __call__()
    #print("Imprimiendo Pureba.__dic__ despues de crear la instancia b: ")
    #print('Prueba.__dict__: ', Prueba.__dict__)
    
    print('a is b: ', a is b) #True

    #Heredero
    #print('Heredero.__dict__', Heredero.__dict__)
    c = Heredero() #Entro al llamado __call__()
    print('c is a: ', c is a ) #False
     
    d = Heredero() #Entro al llamado __call__()
    print('c is d: ', c is d) #True

    #Type
    e = type(a)() #Entro al llamado __call__()
    print('e is a: ', e is a)#True

    #Otra
    f = Otra() #Entro al llamado __call__()
    g = Otra() #Entro al llamado __call__()
    print('f is g: ', f is g) #True

    print(Otra.__mro__)
    #(<class '__main__.Otra'>, <class '__main__.OtraPrueba'>, 
    #<class '__main__.Prueba'>, <class '__main__.Object'>)
    
#Esta via si da solucion al problema correctamente



