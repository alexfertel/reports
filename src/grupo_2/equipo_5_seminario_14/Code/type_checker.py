def add_int(a: int, b: int):
    return a + b


def typeCheckExtended(*types):
    def wrapper(f):
        assert len(types) == f.__code__.co_argcount

        def new_f(*args):
            for (a, t) in zip(args, types):
                if type(t) is tuple:
                    assert any([type(a) == typex for typex in t]), f'{a} is not a valid type'
                else:
                    assert type(a) == t, f'{a} is not a valid type'
            return f(*args)

        return new_f

    return wrapper


def typeCheck(*types):
    def wrapper(f):
        assert len(types) == f.__code__.co_argcount

        def new_f(*args):
            for (a, t) in zip(args, types):
                assert type(a) == t, f'{a} is not a valid type'
            return f(*args)

        return new_f

    return wrapper


@typeCheck(int)
def test(a):
    print(a)


@typeCheckExtended((int, str), (str))
def test_2(a, b):
    print(type(a), type(b))


test_2(False, 1)
# print(add_int(1, 2))
# print(add_int('a', 'b'))
# test('ada')
