from matrix import Matrix

def main():
    print()

    # creamos una matriz de 2x3 con valor 1 en todas sus casillas
    m1 = Matrix(2, 3, 1)
    # creamos una matriz de 2x3 con valor 2 en todas sus casillas
    m2 = Matrix(2, 3, 2)
    # creamos una matriz de 3x4 con valor 5 en todas sus casillas
    m3 = Matrix(3, 4, 5)

    print(m1 + m2)
    print()
    print(m1 * m3)
    print()
    print(m3 * 2)
    print()

    print(m3.transpuesta())
    print()
    
    # creamos una matriz de 2x2 con valor -1 en todas sus casillas
    m4 = Matrix(2, 2, -1)
    # imprimimos la matriz m4
    print(m4)
    print()
    # modificamos la casilla 0,0 al valor -5
    m4[0,0] = -5
    # imprimimos nuevamente m4 para chequear el cambio antes echo
    print(m4)
    print()
    # imprimimos el valor de la casilla 1,1
    print(m4[1,1])
    print()

    m5 = Matrix(2, 2)
    # creamos la matriz [ [1,2] , [3,4] ]
    m5[0,0], m5[0,1], m5[1,0], m5[1,1] = 1, 2, 3, 4
    print(m5)
    print()

    # iteramos la matriz m5
    iterator5 = iter(m5)
    while True:
        try:
            current = next(iterator5)
            print(current, end=' ')
        except StopIteration:
            print()
            break

    # otra forma de iterar
    for i in m5:
        print(i, end=' ')
    print()

    iterator = reversed(m5)
    while True:
        try:
            current = next(iterator)
            print(current, end=' ')
        except StopIteration:
            print()
            break
    
    print(m5.determinante())
    print()

    m6 = m5 ** 5
    print(m6)
    print()

    print(m6.determinante())
    print()

if __name__ == '__main__':
    main()