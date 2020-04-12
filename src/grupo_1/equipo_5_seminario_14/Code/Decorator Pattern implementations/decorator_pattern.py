#Ejemplo Python
def establecer_costo_decorator(funcion):
    def envoltorio1(instancia, costo):
        funcion(instancia, costo)
    return envoltorio1


def obtener_costo_decorator(costo_adicional):
    def envoltorio1(funcion):
        def envoltorio2(instancia):
            return funcion(instancia) + costo_adicional
        return envoltorio2
    return envoltorio1


class Cafe(object):
    @establecer_costo_decorator
    def establecer_costo(self, costo):
        self.costo = costo

    @obtener_costo_decorator(0.5)
    @obtener_costo_decorator(0.7)
    @obtener_costo_decorator(0.2)
    def obtener_costo(self):
        return self.costo


cafe = Cafe()
cafe.establecer_costo(1.0)
print(cafe.obtener_costo())  # 2.4
