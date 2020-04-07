# Equipo # 7 
#### Alejandro E. Domínguez</br> Juan Carlos Vázquez</br>Juan Carlos Esquivel</br>Yandy Sánchez</br>Eric Martin

</br>

# Seminario # 16
## Lenguajes dinámicos 1

## __Conceptos Generales__

### __Clases en Python:__
Las clases en Python proveen una forma de empaquetar datos y funcionalidades juntas. Al crear una nueva clase se crea un nuevo tipo de objeto permitiendo crear nuevas instancias de ese tipo. Las clases también participan en la naturaleza dinámica de Python (se crean en tiempo de ejecución y pueden modificarse luego de su creación). 
```python
class classname:
	<declaración 1>
	…
	…
	…
	<declaración n>
```
</br>

### __Métodos de clase en Python:__
Para definir métodos de una clase en Python utilizamos la siguiente sintaxis:
```python
class classname:
    def methodname(self, args):
        #implementacion del método
        pass
```
Utilizamos ```self``` como primer parámetro de los métodos porque al utilizar la notación ```X.methodname()``` donde ```X``` es una instancia de ```classname``` Python automáticamente le pasa como primer parámetro al método la instancia ```X```. Para los métodos que no sean particulares de la instancia esto no es necesario y los invocamos de la forma ```classname.method2()```   (funciones estáticas en C#)

También podemos generar objetos funciones utilizando la notación lambda. Al utilizar def lo que hacemos es asignarle una función a un nombre. Al utilizar la notación lambda devolvemos la función permitiéndonos asignársela a un nombre o utilizarla como función anónima. Las funciones lambda se crean utilizando la siguiente sintaxis:
```
lambda param1, param2, … , paramN : expresión
```


### __Sobrecarga de operadores:__
* Es la acción de interceptar operaciones built-in e invocar métodos definidos en la clase para realizar estas. Python se encarga automáticamente de invocar a los métodos de una clase cuando instancias de esta aparecen en operaciones built-in. Esto permite que nuestras clases se asemejen más a los tipos built-in del lenguaje.
* Para implementar la sobrecarga de operadores en una clase nuestra debemos definir en ella métodos con nombres específicos.

</br>

| Método                             | Invocados por:                     |
|------------------------------------|------------------------------------|
|```__init__```                      |Creación de un objeto: x=Class(args)|
|```__add__```                       |X+Y                                 |
|```__or__```                        |X or Y                              |
|```__str__```                       |```print(X), str(X)```         |
|```__getattr__```                   |```X.Undefined```               |
|```__getattribute__```              |```X.Defined```                 |
|```__getitem__```                   |```X[key]```                    |
|```__setitem__```                   |```X[key]=value```              |
|```__iter__ , __next__```           |```for i in X```                |



</br>     

### __Expresiones Generadoras:__
Estos conceptos son bastante parecidos en su sintaxis, la única diferencia es que el primero se escribe entre paréntesis y el segundo entre corchetes.
Las expresiones generadoras devuelven un objeto generador que produce resultados por demanda.
```python
Gen = (x**2 for x in range(1000))
```
En cada iteración del objeto Gen nos va a devolver el valor que devuelva el iterador range(1000) aplicándole la función x**2.

</br>

### __List Comprehension:__
Las List Comprehensions coleccionan el resultado de aplicar una expresión a una secuencia de valores y los retornan en una nueva lista.
Supongamos que queremos guardar el código ASCII de todos los caracteres de un string. Quizas lo primero que se nos ocurra sea algo como esto:
```python
res = []
for x in 'listCopm':
    res.append(ord(x))
```
Pero utilizando una expresión de List Comprehension podemos lograr el mismo resultado con algo así:
```python
res = [ord(x) for x in 'listComp']
```
Las List Comprehension son incluso más generales, permitiéndonos utilizar una condición luego del for para agregar una selección lógica de los elementos.
```python
res = []
for x in range(5):
    if x % 2 == 0:
        res.append(x**2)
```
```python
res = [x**2 for x in range(5) if x % 2 == 0]
```
Ambos códigos producen el mismo resultado, y no es difícil apreciar cuál de los dos es más conciso.

>Debemos tener en cuenta que las List Comprehension  pueden llegar a ser bastante engorrosas debido al anidamiento de ciclos for que podemos hacer en ellas. Sin embargo, en estos casos, existe una ganancia substancial en cuanto a rendimiento al usar éstas a pesar de su complejidad extra, ya que las Comprehension List son el doble de rápidas que los ciclos for corrientes. Esto se debe a que las List Comprehensions corren a velocidad de lenguaje C en el intérprete, que es mucho mas rápido que entrar en la MVP del ciclo for de Python.

</br>

-----

## **Ejercicio del Seminario:** </br>Implemente los siguientes iterables en Python, con y sin generadores:
### __1. Conjunto de Wirth__

El conjunto wirth es un conjunto q tiene la siguiente definición:
* 1 pertenece al conjunto
* Si x pertenece entonces x*2+1 pertenece y x*3+1 pertenece
En la funcion __next__ vamos controlando la forma de ir retornado los elementos y cuando se llega a la cantidad
requerida por la instancia de la clase entonces se lanza la excepción StopIteration q es la forma que tiene python
de detener el proceso de iteración.

</br>

### __Solución__:
```python
class WirthIter:
    def __init__(self,count:int):
        self.count = count
        self.i = 0
        self.current = 1
        self.even = []
        self.odd = []
```
```python                                                               
    #La forma de iterar sin Generador                          
    def __iter__(self):                                        
        return self                                            
                                                               
    def __next__(self):                                        
        if self.i == self.count:                               
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
```
> La funcion ```__iter__``` devuelve el iterador a recorrer, si se retorna self, la misma clase será este iterador, de ahí que la forma de moverse lo decide la función ```__next__```, la cual implementa la forma en la que el iterador retorna los elementos.

```python
    #La forma de iterar con Generador
        def __iter__(self):
            i=0
            while i < self.count:
                yield self.current
                i += 1
                self.even.append(2 * self.current + 1)
                self.odd.append(3 * self.current + 1)
                if self.even[0] < self.odd[0]:
                    self.current = self.even[0]
                    self.even.__delitem__(0)
                else :
                    self.current = self.odd[0]
                    self.odd.__delitem__(0)
```
>Las expresiones generadoras son similares a las comprensiones de lista pero estas retornan un objeto que produce resultados en demanda, por lo que al usar el ```yield``` en la funcion ```__iter__```, estamos generando un iterador sobre el cual se va trabajar en el momento que se tome una instancia de la clase ```WirthIter``` como iterador. </br>Fijese que en este caso no se implemento la funcion ```__next__``` porque estamos retornando el objeto a iterar y en este caso no es necesario redefinir la forma de iterar por la clase.

</br>

### __2. ConcatIterable: Iterable conformado por los elementos de dos iterables puestos a continuación.__


### __Solución__:
```python
class ConcatIterable:
    def __init__(self,firstIter,secondIter):
        self.first = firstIter
        self.second = secondIter
```
```python
    #La forma de iterar sin Generador
    def __iter__(self):
        return self

    def __next__(self):
        try:
           value = self.first.__next__()
        except:
            try:
                value = self.second.__next__()
            except:
                raise StopIteration 
```
>Se modifica la función ```__next__``` de forma tal que, cuando acabe con los elementos del primer iterable, continue con el segundo y lance la excepción ```StopIteration``` cuando no tenga mas objetos por los que iterar.
```python
    #La forma de iterar con Generador
    def __iter__(self):
        for x in self.first:
            yield x
        for y in self.second:
            yield y
```
>Auxiliándonos del generador ```yield``` podemos recorrer ambos iteradores y formar un objeto iterable
que contiene todos los elementos del primero y segundo iterable puestos uno a continuacion del otro.
Existen muchas otras opciones como guardar los elementos en una lista mas grande o simplemente retornar ```self``` 
y modificar el comportamiento de la funcion ```__next__``` pero en este ejemplo solo usando la función ```__iter__``` se soluciona el problema en muy pocas líneas.

</br>

### __3. WhereIterable: Iterable conformado por aquellos elementos de un iterable que cumplen un determinado predicado.__

### __Solución__:

```python
class WhereIterable:
    def __init__(self,iter,predicado):
        self.iter = iter
        self.predicado = predicado
        self.current = 0
```
```python  
    #La forma de iterar sin Generador
    def __iter__(self):
        return self
    
    def __next__(self):
        try:
            self.current = self.iter.__next__()
            try:
                if not self.predicado(self.current)
            except:
                SyntaxError("El predicado no retorna un bool")
            while not self.predicado(self.current):
                self.current = self.iter.__next__()
            return self.current
        except:
            raise StopIteration
```
>Se verifica que mientras no se cumpla el predicado continue al próximo elemento. En caso que se terminen los elementos
del iterable la función ```__next__``` lanza una excepción la cual es capturada y envía una ```StopIteration```
```python
    #La forma de iterar con Generador
    def __iter__(self):
        for x in self.iter:
            try:
                if self.predicado(x):
                    yield x
            except:
                raise SyntaxError("El predicado no devuelve un bool")
```
>En este caso el try solo cuida que el predicado de la entrada retorne un valor booleano.

</br>

### __4. Valore el mecanismo para indicar fin de iteración en Python.__

</br>

Como hemos visto durante el seminario el mecanismo que existe en Python para indicar el fin de iteración es lanzar una excepción ```StopIteration```.

Aunque este mecanismo sigue la filosofía de Python: ¨Es mejor pedir perdón que pedir permiso¨, no creemos que sea la forma más adecuada de indicar el fin de iteración, debido al riesgo que lleva consigo manejar código mediante excepciones. Algunas variantes propuestas para cambiar esto son:
* Tener un valor especial que indique el final de la colección.
* Una función ```End()``` que indique si terminó o no la colección.
