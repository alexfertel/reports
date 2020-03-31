
# Seminarios de Lenguajes Dinámicos II

## Seminario 18 - Python V

1- Implemente un módulo llamado **`functionTools`** donde se encuentren las siguientes definiciones:

* **`fixParams`**: Función que permite “fijar” valores como argumentos de funciones. Por ejemplo, fijar el valor 2 como primer argumento de una función **`f`** con tres parámetros consiste en obtener una función **`g`** de 2 parámetros de manera que **`g(a, b)`** sea equivalente a hacer **`f(2, a, b)`** . Para esto **`fixParams`** recibe como primer argumento la función seguida de los valores que se quieren fijar. Por ejemplo, la siguiente línea fija los valores 6 y 7 como segundo y cuarto argumento respectivamente de una función de cuatro parámetros. **`g = fixParams(f, _, 6, _, 7)`**. El valor especial **`_`** (guión bajo) debe ser definido en el módulo functionTools para indicar que un parámetro no tiene valor fijo. Luego de la línea del ejemplo hacer **`g(1, 2)`** es equivalente a hacer **`f(1, 6, 2, 7)`**.

* **`_`**: valor especial para indicar un parámetro sin valor fijo en la función **`fixParams`**.

> Resto de la orientción...

### **`fixParams`**

Par poder explicar directamente esta función pondremos directamente el código y a continuación lo explicaremos.

Definimos el tipo **`_`** para poder ser usado en la función **`fixParams`** como indicador de pará metro libre.

```python
class Ignore:
    pass


_ = Ignore()
```

```python
def fixParams(func, *args, **kwargs):
    fixed_args = args
    fixed_kwargs = kwargs

    def newFunction(*args, **kwargs):
        i = j = 0
        newArgs = []
        while i < len(fixed_args) and j < len(args):
            if type(fixed_args[i]) is not Ignore:
                newArgs.append(fixed_args[i])
                i += 1
            else:
                newArgs.append(args[j])
                j += 1
        while i < len(fixed_args):
            if type(fixed_args[i]) is not Ignore:
                newArgs.append(fixed_args[i])
            i += 1
        while j < len(args):
            newArgs.append(args[j])
            j += 1

        for key, value in fixed_kwargs.items():
            kwargs[key] = value
        func(*newArgs, **kwargs)

    return newFunction
```

En el código anterior vamos a identificar y describir las siguientes variables:

- **`func`**: es la función a la cual se le quiere fijar valores en los argumentos
- **`fixed_args`**: es la tupla con el conjunto de valores fijos y libres. Por ejemplo `(_, 6, _, 7)`
- **`fixed_kwargs`**: es el conjunto de argumentos con valores por defecto, si existen, serán los últimos argumentos de la función.  ¿Para qué queremos usar **`kwargs`** en este caso? Si **`func`** tiene varios **`kwargs`** sería cómodo poder fijarle valores a un conjunto de esos **`kwargs`**, esto nos permite cambiar el valor por defecto que tenía.
- **`newFunction`**: es la función con los cambios realizados y que será devuelta por **`fixParams`**.
- **`newArgs`**: es el nuevo vector de argumentos que será utilizado.

En el cuerpo de **`newFunction`** se pueden ver tres ciclos **`while`** seguidos, que van a implementar la estrategia de reemplazo de los argumentos. El remplazo de argumentos sigue la siguiente estrategia:

- El i-esimo elemento de **`args`** será puesto en el i-esimo argumento libre ( **`_`** ) de **`fixed_args`**. Es decir si **`args = (1,3)`** y **`fixed_args = (0,_,2,_)`** el resultado es **`(0,1,2,3)`**. 
- Si hay más elementos en **`args`** que espacios libres en **`fixed_args`**, entonces simplemente el resto se agrega al final, por ejemplo, **`args = (1,3,4,5)`** y **`fixed_args = (0,_,2,_)`** el resultado es **`(0,1,2,3,4,5)`**.
- Si hay más espacios libres en **`fixed_args`** que elementos en **`args`**, entonces son ignorados los que sobran, por ejemplo, **`args = (1,3)`** y **`fixed_args = (0,_,2,_,_,_)`** el resultado es **`(0,1,2,3)`**

Tener en cuanta la definición de la función **`newFunction`** dentro de la función **`fixParams`**, esto es posible en Python ya que en este lenguaje las funciones son ciudadanos de primer orden.

Notar también que **`newFunction`** termina con el llamado a la función original **`func`** con los argumentos modificados.

