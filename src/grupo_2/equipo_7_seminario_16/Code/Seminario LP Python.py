#Iteradores En Python

#Conjunto Wirth
# (1 pertenece al conjunto)
# si x pertenece 2*x + 1 pertenece y 3*x + 1 pertenece

class WirthIter:
    def __init__(self,count:int):
        self.count = count
        self.i = 0
        self.current = 1
        self.even = []
        self.odd = []
                                                               ################################################################
    #La forma de iterar sin Generador                          # La funcion __iter__ devuelve el iterador a recorrer,         #
    def __iter__(self):                                        # si se retorna self, la misma clase será este iterador,       #
        return self                                            # de ahi que la forma de moverse lo decide la función __next__,#
                                                               # la cual implementa la forma en la que el iterador retorna    #
    def __next__(self):                                        # los elementos.                                               #
        if self.i == self.count:                               ################################################################
            raise StopIteration
        self.i += 1
        old_current = self.current
        self.even.append(2 * self.current + 1)
        self.odd.append(3 * self.current + 1)
        if self.even[0] < self.odd[0]:
            self.current = self.even[0]
            self.even.__delitem__(0)
        else:
            self.current = self.odd[0]
            self.odd.__delitem__(0)
        return old_current

    ##La forma de iterar con Generador
    #def __iter__(self):
    #    i=0
    #    while i < self.count:
    #        yield self.current
    #        i += 1
    #        self.even.append(2 * self.current + 1)
    #        self.odd.append(3 * self.current + 1)
    #        if self.even[0] < self.odd[0]:
    #            self.current = self.even[0]
    #            self.even.__delitem__(0)
    #        else :
    #            self.current = self.odd[0]
    #            self.odd.__delitem__(0)

a = WirthIter(5)
for x in a:
    print(x)
    
class ConcatIterable:
    def __init__(self,firstIter:iter,secondIter:iter):
        self.first = firstIter.__iter__()
        self.second = secondIter.__iter__()

    ##La forma de iterar sin Generador
    #def __iter__(self):
    #    return self
    #
    #def __next__(self):
    #    try:
    #       value = self.first.__next__()
    #       return value
    #    except:
    #        try:
    #            value = self.second.__next__()
    #            return value
    #        except:
    #            raise StopIteration

    
    #La forma de iterar con Generador
    def __iter__(self):
        for x in self.first:
            yield x
        for y in self.second:
            yield y

concat = ConcatIterable(range(10,15),range(15,20))
for x in concat:
    print(x)

class WhereIterable:
    def __init__(self,iter,predicado):
        self.iter = iter.__iter__()
        self.predicado = predicado
        self.current = 0
    
    ##La forma de iterar con Generador
    #def __iter__(self):
    #    return self
    #          
    #def __next__(self):
    #    try:
    #        self.current = self.iter.__next__()
    #        try:
    #            if not self.predicado(self.current):
    #                return self.current
    #        except:
    #            SyntaxError("El predicado no retorna un bool")
    #        while not self.predicado(self.current):
    #            self.current = self.iter.__next__()
    #        return self.current
    #    except:
    #        raise StopIteration

    #La forma de iterar con Generador
    def __iter__(self):
        for x in self.iter:
            try:
                if self.predicado(x):
                    yield x
            except:
                raise SyntaxError("EL predicado no retorna un bool")

def EsPrimo(x:int):
    
    if x == 2:
        return True
    
    i = 2
    while i*i <= x:
        if x%i == 0:
            return False
        i += 1
    return True    

Primos = WhereIterable(range(2,15),EsPrimo)

for k in Primos:
    print(k)