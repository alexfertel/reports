class Ignore:
    pass


_ = Ignore()


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


def rearrangeParam(f, *p):
    def retf(*arg):
        narg = [0 for i in range(len(p))]
        for i in range(len(p)):
            narg[p[i]] = arg[i]
        arg = narg
        return f(*arg)
    return retf


# Versión mejorada 
# def rearrangeParam(f, *args):
#     def newFunc(*kargs):
#         return f(*(kargs[i] for i in args))
#     return newFunc

