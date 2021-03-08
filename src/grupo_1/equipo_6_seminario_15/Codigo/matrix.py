class Matrix:

    def __init__(self, rows, columns, value=0):
        '''
        Constructor de la clase Matrix.
        '''
        if rows <= 0 or columns <= 0:
            raise Exception('LAS DIMENSIONES DEBEN SER POSITIVAS.')
        if not isinstance(value, int):
            raise Exception('LA MATRIZ DEBE SER DE ENTEROS.')

        self.rows = rows
        self.columns = columns
        self.matrix = [[value for _ in range(self.columns)] 
                                        for _ in range(self.rows)]

    def __add__(self, other):
        '''
        Redefiniendo el operador '+'.
        '''
        if not isinstance(other, Matrix):
            raise Exception('LAS MATRICES SE SUMAN ENTRE ELLAS.')
        if self.rows != other.rows or self.columns != other.columns:
            raise Exception('LAS MATRICES DEBEN TENER DIMENSIONES IGUALES PARA SER SUMADAS.')

        matrix_add = Matrix(self.rows, self.columns)

        for i in range(self.rows):
            for j in range(self.columns):
                matrix_add.matrix[i][j] = self.matrix[i][j] + \
                                                    other.matrix[i][j]
        return matrix_add

    def __sub__(self, other):
        '''
        Redefiniendo el operador '-'.
        '''
        if not isinstance(other, Matrix):
            raise Exception('LAS MATRICES SE RESTAN ENTRE ELLAS.')
        if self.rows != other.rows or self.columns != other.columns:
            raise Exception('LAS MATRICES DEBEN TENER DIMENSIONES IGUALES PARA SER RESTADAS.')

        matrix_sub = Matrix(self.rows, self.columns)
        for i in range(self.rows):
            for j in range(self.columns):
                matrix_sub.matrix[i][j] = self.matrix[i][j] - \
                                                other.matrix[i][j]

        return matrix_sub

    def __mul__(self, other):
        '''
        Redefiniendo el operador '*'. Tenemos en cuenta la 
        multiplicacion de matrices y el producto por un escalar.
        '''
        if not isinstance(other, Matrix) and not isinstance(other, int):
            raise Exception('LAS MATRICES SOLO PUEDEN SER MULTIPLICADAS POR OTRA MATRIZ O POR UN NUMERO ENTERO.')

        if isinstance(other, int):
            matrix_mul = Matrix(self.rows, self.columns)
            for i in range(self.rows):
                for j in range(self.columns):
                    matrix_mul.matrix[i][j] = self.matrix[i][j] * other
            return matrix_mul
        else:
            if self.columns != other.rows:
                raise Exception('NO SE PUEDEN MULTIPLICAR LAS MATRICES.')

            matrix_mul = Matrix(self.rows, other.columns)

            for i in range(self.rows):
                for j in range(other.columns):
                    for k in range(self.columns):
                        matrix_mul.matrix[i][j] += self.matrix[i][k] * other.matrix[k][j]

            return matrix_mul

    def __truediv__(self, n):
        '''
        Redefiniendo el operador '/'.
        '''
        return self.__floordiv__(n)

    def __floordiv__(self, n):
        '''
        Redefiniendo el operador '//'.
        '''
        if not isinstance(n, int):
            raise Exception('LAS MATRICES SOLO PUEDEN DIVIDIRSE POR NUMEROS ENTEROS.')

        matrix_div = Matrix(self.rows, self.columns)
        for i in range(self.rows):
            for j in range(self.columns):
                matrix_div.matrix[i][j] = self.matrix[i][j] // n

        return matrix_div

    def __pow__(self, n):
        '''
        Redefiniendo el operador '**'.
        '''
        if not self.is_square():
            raise Exception('SOLO SE PUEDEN ELEVAR MATRICES CUADRADAS.')
        if not isinstance(n, int) and n < 0:
            raise Exception('EL EXPONENTE DEBE SER UN ENTERO MAYOR QUE 0.')

        if n == 0:
            new_matrix = Matrix(self.rows, self.columns, 0)
            for i in range(new_matrix.rows):
                new_matrix[i,i] = 1
            return new_matrix
        elif n % 2 == 0:
            matrix_clone = self.clone()
            new_matrix = matrix_clone ** (n / 2)
            return new_matrix * new_matrix
        else:
            matrix_clone = self.clone()
            new_matrix = matrix_clone ** (n - 1)
            return matrix_clone * new_matrix

    def __getitem__(self, indexs):
        '''
        Para que se pueda indexar el objeto Matrix de la forma
        matrix[fila,columna].
        '''
        if not isinstance(indexs, tuple) or len(indexs) != 2:
            raise Exception('EL INDICE DEBE SER DE LA FORMA fila,columna.')
        if indexs[0] >= self.rows or indexs[1] >= self.columns:
            raise Exception('INDICES FUERA DE RANGO.')

        i,j = indexs
        return self.matrix[i][j]

    def __setitem__(self, indexs, value):
        '''
        Para que se pueda modificar el objeto Matrix de la forma
        matrix[fila,columna] = value.
        '''
        if not isinstance(indexs, tuple) or len(indexs) != 2:
            raise Exception('EL INDICE DEBE SER DE LA FORMA (fila,columna).')
        if not isinstance(value, int):
            raise Exception('LA MATRIZ DEBE SER DE ENTEROS.')
        if indexs[0] >= self.rows or indexs[1] >= self.columns:
            raise Exception('INDICES FUERA DE RANGO.')
        
        i,j = indexs
        self.matrix[i][j] = value

    def __contains__(self, n):
        '''
        Para que se pueda buscar un elemento en el objeto Matrix.
        '''
        if not isinstance(n, int):
            raise Exception('LA MATRIZ ES DE ENTEROS.')

        for i in range(self.rows):
            for j in range(self.columns):
                if self.matrix[i][j] == n:
                    return True
        return False

    def __eq__(self, other):
        '''
        Redefiniendo el operador '=='.
        '''
        if not isinstance(other, Matrix):
            raise Exception('LAS COMPARACIONES DEBEN REALIZARSE ENTRE MATRICES.')
        if self.rows != other.rows or self.columns != self.columns:
            return False

        for i in range(self.rows):
            for j in range(self.columns):
                if self.matrix[i][j] != other.matrix[i][j]:
                    return False
        return True

    def __str__(self):
        '''
        Para imprimir matrices de forma mas clara y concisa.
        '''
        text = ''
        for i in range(self.rows):
            for j in range(self.columns):
                text += str(self.matrix[i][j]) + ' '
            if i != self.rows - 1:
                text += '\n'
        return text

    def __iter__(self):
        '''
        Para poder iterar el objeto Matrix.
        '''
        return MatrixIterator(self)

    def __reversed__(self):
        '''
        Para poder iterar el objeto Matrix en orden reverso.
        '''
        return MatrixIteratorReverse(self)

    def clone(self):
        '''
        Clona al objeto Matrix, devolviendo una instancia de esta 
        misma clase con los atributos idenicos.
        '''
        matrix_clone = Matrix(self.rows, self.columns)
        matrix_clone.matrix = [[self.matrix[i][j] 
                                    for i in range(self.rows)] 
                                        for j in range(self.columns)]
        return matrix_clone

    def is_square(self):
        '''
        Devuelve si la matriz es cuadrada.
        '''
        return self.rows == self.columns

    def transpuesta(self):
        '''
        Hallar la transpuesta de la matriz.
        '''
        matrix_trans = Matrix(self.columns, self.rows)
        matrix_trans.matrix = [[self.matrix[i][j] 
                                    for i in range(self.rows)] 
                                        for j in range(self.columns)]
        return matrix_trans

    def determinante(self):
        '''
        Calcula el determinante de una matriz.
        '''
        if not self.is_square():
            raise Exception('LA MATRIZ DEBE SER CUADRADA PARA EL CALCULO DEL DETERMINANTE.')

        if self.rows == 1:
            return self.matrix[0][0]
        elif self.rows == 2:
            return self.matrix[0][0] * self.matrix[1][1] - self.matrix[1][0] * self.matrix[0][1]
        elif self.rows == 3:
            return self.matrix[0][0] * self.matrix[1][1] * self.matrix[2][2] + self.matrix[0][1] * self.matrix[1][2] * self.matrix[2][0] + self.matrix[0][2] * self.matrix[1][0] * self.matrix[2][1] - (self.matrix[2][0] * self.matrix[1][1] * self.matrix[0][2] + self.matrix[2][1] * self.matrix[1][2] * self.matrix[0][0] + self.matrix[2][2] * self.matrix[1][0] * self.matrix[0][1])
        else:
            new_matrix = Matrix(self.rows - 1, self.columns - 1)
            deter = 0
            count = 0

            while count != self.rows:

                for i in range(self.rows):
                    for j in range(self.columns):
                        if i == 0 or j == count:
                            continue
                        elif j < count:
                            new_matrix[i-1,j] = self.matrix[i][j]
                        else:
                            new_matrix[i-1,j-1] = self.matrix[i][j]

                deter += pow(-1, count) * self.matrix[0][count] * new_matrix.determinante()
                count += 1

            return deter

class MatrixIterator:

    def __init__(self, matrix):
        '''
        Constructor de la clase MatrixIterator.
        '''
        if not isinstance(matrix, Matrix):
            raise Exception('ES UN ITERADOR DEL OBJETO Matrix.')

        self.matrix = matrix
        self.current = 0

    def move_next(self):
        '''
        Devuelve si existe un proximo valor en la iteracion.
        '''
        return self.current < self.matrix.rows * self.matrix.columns

    def __iter__(self):
        '''
        Permite la iteracion del objeto MatrixIterator.
        '''
        return self

    def __next__(self):
        '''
        Devuelve el siguiente valor en la iteracion.
        '''
        if self.move_next():
            new_row = self.current // self.matrix.columns
            new_column = self.current % self.matrix.rows
            value = self.matrix.matrix[new_row][new_column]
            self.current += 1
            return value
        else:
            self.current = 0
            raise StopIteration('NO HAY MAS ELEMENTOS A ITERAR.')

class MatrixIteratorReverse:

    def __init__(self, matrix):
        '''
        Constructor de la clase MatrixIteratorReverse.
        '''
        if not isinstance(matrix, Matrix):
            raise Exception('ES UN ITERADOR DEL OBJETO Matrix.')

        self.matrix = matrix
        self.current = self.matrix.rows * self.matrix.columns - 1

    def move_next(self):
        '''
        Devuelve si existe un proximo valor en la iteracion.
        '''
        return self.current >= 0

    def __iter__(self):
        '''
        Permite la iteracion del objeto MatrixIterator.
        '''
        return self

    def __next__(self):
        '''
        Devuelve el siguiente valor en la iteracion.
        '''
        if self.move_next():
            new_row = self.current // self.matrix.columns
            new_column = self.current % self.matrix.rows
            value = self.matrix.matrix[new_row][new_column]
            self.current -= 1
            return value
        else:
            self.current = 0
            raise StopIteration('NO HAY MAS ELEMENTOS A ITERAR.')

