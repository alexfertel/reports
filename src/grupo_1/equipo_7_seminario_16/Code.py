class ConcatIterableIterator:
    def __init__(self, *args):
        self.Iters = [it for it in args]
        self.Ind_iter_act = 0
        self.UpdateIter()

    def UpdateIter(self):
        self.Iter_act = iter(self.Iters[self.Ind_iter_act])

    def __iter__(self):
        return self
    def __next__(self):
        try:
            value = next(self.Iter_act)
            return value
        except StopIteration:
            if self.Ind_iter_act == len(self.Iters)-1:
                self.Ind_iter_act = 0
                self.UpdateIter()
                raise StopIteration
            self.Ind_iter_act+=1
            self.UpdateIter()
            value = next(self.Iter_act)
            return value

def ConcatIterableGenerator(*args):
    for It in args:
        for i in It:
            yield i


class WhereIterableIterator:
    def __init__(self, It, pred):
        self.It = iter(It)
        self.pred = pred
    def __iter__(self):
        return self
    def __next__(self):
        try:
            value = next(self.It)
            while not self.pred(value):
                value = next(self.It)
            return value
        except StopIteration:
            raise StopIteration

def WhereIterableGenerator(It, pred):
    It = iter(It)
    for i in It:
        if pred(i):
            yield i

class WirthIterableIterator:
    def __init__(self):
        self.cola = [1]
    def __iter__(self):
        return self
    def __next__(self):
        value = self.cola.pop()
        self.cola.insert(0, value*2+1)
        self.cola.insert(0, value*3+1)
        return value

def WirthIterableGenerator():
    cola = [1]
    while True:
        value = cola.pop()
        cola.insert(0, value*2+1)
        cola.insert(0, value*3+1)
        yield value


class prueba():
    def __init__(self):
        self.cont = 0
    def __iter__(self):
        return self
    def __next__(self):
        if self.cont > 3:
            raise StopIteration
        self.cont+=1
        print("Metodo Next")

def gen():
    cont =0
    while True:
        cont += 1
        yield cont


a = [1,2,3,4,5]
b = [6,7,8,9,10]
d = [11,12,13,14,15]

# c = ConcatIterableGenerator(a,b,d)
# c = WhereIterableIterator(a, lambda x: x%2==0)
pred = lambda y: y % 2 == 0
it = d
where = (x for x in it if pred(x) )
c = WhereIterableGenerator(a, lambda x: x % 2 == 0)
c = WirthIterableGenerator()
# c = gen()
# d = (x**2 for x in range(1001))
# for i in d:
#     print(i)
for i in where:
    print(i)

# print(next(c))
# print(next(c))
# print(next(d))
# for i in c:
#     pass

# for i in c:
#     print(i)
# c = ConcatIterableIterator(a,b,d)
# for i in c:
#     print(i)