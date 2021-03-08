class ObjetoInmutable:
    def __init__(self, **kwargs):
        for key, value in kwargs.items():
            super(ObjetoInmutable, self).__setattr__(key, value)

    def __setattr__(self, *args):
        raise AttributeError("Este es un objeto inmutable")
    
    __delattr__ = __setattr__
    __dict__ = None



class Prueba(ObjetoInmutable):
    pass

class Hereda(Prueba):
    pass

class Mutable(ObjetoInmutable):
    __setattr__ = object.__setattr__
    __delattr__ = object.__delattr__
    __dict__ = {}


if __name__ == '__main__':
    a = Prueba(name="Yami")
    print(a.name)

    #a.name = "Dayrene"
    #sprint(a.name) #Error, objeto inmutable

    b = Hereda(lastname = "Reynoso")
    print(b.lastname)

    #b.lastname = "Diaz"
    #print(b.lastname) #Error, objeto inmutable

    c = Mutable(name = "Day")
    print(c.name)

    c.name = "Yamile"
    print(c.name)#No hay error, el objeto es mutable
