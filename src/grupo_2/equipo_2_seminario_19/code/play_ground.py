# import inspect, itertools

# def my_decorator(func):
#     def wrapper(*args, **kwargs):
#         print("Something is happening before the function is called.")
#         func(*args, **kwargs)
#         print("Something is happening after the function is called.")
#     return wrapper

# @my_decorator
# class Circle:
#     def __init__(self, radius):
#         self._radius = radius

#     @property
#     def radius(self):
#         """Get value of radius"""
#         return self._radius

#     @radius.setter
#     def radius(self, value):
#         """Set radius, raise error if negative"""
#         if value >= 0:
#             self._radius = value
#         else:
#             raise ValueError("Radius must be positive")

#     @property
#     def area(self):
#         """Calculate area inside circle"""
#         return self.pi() * self.radius**2

#     def cylinder_volume(self, height):
#         """Calculate volume of cylinder with circle as base"""
#         return self.area * height

#     @classmethod
#     def unit_circle(cls):
#         """Factory method creating a circle with radius 1"""
#         return cls(1)

#     @staticmethod
#     def pi():
#         """Value of π, could use math.pi instead though"""
#         return 3.1415926535

# @my_decorator
# def func_decorator():
#     print("func_decorator")

# @my_decorator
# @my_decorator
# def func_with_args_decorator(a, b, c):
#     print(f"func_with_args_decorator: {a}, {b}, {c}")


# def func():
#     print("func")

# def func_with_args(a, b, c):
#     print(f"func_with_args: {a}, {b}, {c}")

# func_decorator()
# func_with_args_decorator(1, 2, 3)

# my_decorator(func)()
# my_decorator(func_with_args)(1, 2, 3)

# Anidado
# func_with_args_decorator(1, 2, 3)

# my_decorator(my_decorator(func_with_args))(1, 2, 3)



# c = Circle(3)

# print(type(c))

# def decorator(require, ensure):
    
#     try:
#         if not callable(require):
#             raise Exception("require statement must be callable!!")
#         if not callable(ensure):
#             raise Exception("ensure statement must be callable!!")
#     except NameError:
#         pass

#     req_sig = inspect.signature(require)
#     ens_sig = inspect.signature(ensure)

#     def func_wrapper(func):
#         def args_wrapper(*args, **kwargs):
#             req_params = []
#             ens_params = []
            
#             # names and values as a dictionary:
#             instance_dict = {}
#             args_name = inspect.getfullargspec(func)[0]
#             args_dict = dict(itertools.zip_longest(args_name, args))

#             for attribute, value in args[0].__dict__.items():
#                 instance_dict[attribute] = value

#             for param in req_sig.parameters:
#                 if str(param) in args_dict.keys():
#                     req_params.append(args_dict[str(param)])
#                 elif str(param) in instance_dict.keys():
#                     req_params.append(instance_dict[str(param)])
#                 else:
#                     raise Exception("pre-condition params could not be found")

#             for param in ens_sig.parameters:
#                 if str(param) in args_dict.keys():
#                     ens_params.append(args_dict[str(param)])
#                 elif str(param) in instance_dict.keys():
#                     ens_params.append(instance_dict[str(param)])
#                 else:
#                     raise Exception("pos-condition params could not be found")

#             if require(*req_params):
#                 value = func(*args, **kwargs)

#                 if ensure(*ens_params):
#                     return value
#                 else:
#                     raise Exception("pos-conditions fails")
#             else:
#                 raise Exception("pre-conditions fails")
#         return args_wrapper
#     return func_wrapper


# class car():
# 	# init method or constructor
#     def __init__(self, model, color, number):
#         self.model = model
#         self.number = number
#         self.color = color

#     @decorator(require=lambda entero: entero >= 0, ensure=lambda entero2, number: entero2 <= number)
#     def show(self, entero: int, text: str, entero2: int):
#         return "If i get printed out, then everything is ok :)"

# # both objects have different self which
# # contain their attributes
# audi = car("audi a4", "blue", 3)
# # ferrari = car("ferrari 488", "green")

# print(audi.show(1, "a", 2))	 # same output as car.show(audi)
# ferrari.show(2, "b", 3)  # same output as car.show(ferrari)


def time_this(original_function):
    print ("decorating")

    def new_function(*args, **kwargs):
        print ("starting timer")
        import datetime
        before = datetime.datetime.now()
        x = original_function(*args, **kwargs)
        after = datetime.datetime.now()
        print ("Elapsed Time = {0}".format(after-before))
        return x
    return new_function


def contract_invariant(invariant):
    def contract(Cls):
        class NewCls(object):

            def __init__(self, *args, **kwargs):
                self.oInstance = Cls(*args, **kwargs)
                print("pepe")

            def __getattribute__(self, s):
                """
                this is called whenever any attribute of a NewCls object is accessed. This function first tries to 
                get the attribute off NewCls. If it fails then it tries to fetch the attribute from self.oInstance (an
                instance of the decorated class). If it manages to fetch the attribute from self.oInstance, and 
                the attribute is an instance method then `time_this` is applied.
                """
                try:
                    x = super(NewCls, self).__getattribute__(s)
                except AttributeError:
                    pass
                else:
                    return x
                x = self.oInstance.__getattribute__(s)
                if type(x) == type(self.__init__):  # it is an instance method
                    # this is equivalent of just decorating the method with time_this
                    return time_this(x)
                else:
                    return x
                
        return NewCls
    return contract


@contract_invariant(invariant=lambda x: x > 0)
class Foo(object):

    def __init__(self, size):
        self.size = size

    def a(self):
        print ("entering a")
        import time
        time.sleep(3)
        print ("exiting a")


oF = Foo(3)
oF.a()

# the metaclass will automatically get passed the same argument
# that you usually pass to `type`
# def upper_attr(future_class_name, future_class_parents, future_class_attrs):
#     """
#       Return a class object, with the list of its attribute turned
#       into uppercase.
#     """
#     # pick up any attribute that doesn't start with '__' and uppercase it
#     uppercase_attrs = {
#         attr if attr.startswith("__") else attr.upper(): v
#         for attr, v in future_class_attrs.items()
#     }

#     # let `type` do the class creation
#     return type(future_class_name, future_class_parents, uppercase_attrs)




# class Foo(metaclass=upper_attr):  # global __metaclass__ won't work with "object" though
#     # __metaclass__ = upper_attr 
#     # but we can define __metaclass__ here instead to affect only this class
#     # and this will work with "object" children
#     bar = 'bip'

# # of = Foo()
# print(hasattr(Foo, 'bar'))

# print(hasattr(Foo, 'BAR'))
# class contractMetaclass(type):

#     def __new__():
#         pass

#     def __init__():
#         pass

#     def __getattribute__():
#         pass



# class Foo:

#     def __init__(self, size):
#         self.size = size

#     def show_size(self):
#         print(self.size)
