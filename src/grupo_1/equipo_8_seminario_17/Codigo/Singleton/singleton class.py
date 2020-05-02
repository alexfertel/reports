class Singleton:
    intance = None

    def __new__(cls, *args, **kwargs):
        if not isinstance(cls.intance, cls):
            cls.intance = super(Singleton, cls).__new__(cls, *args)
        return cls.intance



class Prueba(Singleton):
    def __init__(self):
        print("Hello")

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
    a = Prueba()
    b = Prueba()
    print('a is b: ', a is b) #True


    #Heredero
    c = Heredero()
    print('a is c: ', a is c) #False
    d = Heredero()
    print('c is d: ', c is d) #True

    #type
    #Corrige el error de los decoradores con el type
    e = type(a)()
    print('e is a: ', e is a)#True

    #Otra
    f = Otra()
    g = Otra()
    print('f is g: ', f is g)#False

    print(Otra.__mro__) 
    #(<class '__main__.Otra'>, <class '__main__.OtraPrueba'>, <class '__main__.Prueba', 
    #<class '__main__.Singleton'>, <class '__main__.Object'>)


#Esta via aunque mejora uno de los errores de la solucion 
#mediante decoredores, no es la mejor, puesto que crea una 
#nueva instancia para cada clase que herede de la clase 
#Prueba, no funciona correctamente con multiples instancias

