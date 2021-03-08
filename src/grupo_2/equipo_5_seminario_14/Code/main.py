from decorators import *


def my_decorator(func):
    def wrapper():
        print('Antes de llamar a la funcion')
        func()
        print('Despues de llamar a la funcion')

    return wrapper


def say_hello():
    print('Hola')


@repeat(4)
def greet(a):
    print(f'Hola {a}')


@run_twice
def return_greet(a):
    return f'Hola {a}'


# salut = my_decorator(say_hello)
# salut()

#print(return_greet('Mundo'))

greet('a')