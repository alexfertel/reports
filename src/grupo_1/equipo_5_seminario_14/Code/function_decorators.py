"""
Function Decorators

Class
"""
class ArgumentFunctionDecoratorClass:
    def __init__(self,*args): # Params Function
        self.args = args
    def __call__(self, func): # Wrap Function
        def inner_func(*args,**kwargs):  # Inner Function
            # Something to do before the func call
            value = func(*args,**kwargs)
            # Something to do after the func call
        return inner_func

@ArgumentFunctionDecoratorClass(1,2,3,4)
def target_function(*args,**kwargs):
    # Function body
    pass
target_function()

class FunctionDecoratorClass:
    def __init__(self,func): # Wrap Function
        self.func = func
    def __call__(self, *args,**kwargs): # Inner Function
        # Something to do before the func call
        value = self.func(*args,**kwargs)
        # Something to do after the func call

@FunctionDecoratorClass
def target_function(*args,**kwargs):
    # Function body
    pass
target_function()

"""
Function Decorators

Function
"""

def decorator(func): # Wrap Function
    def inner_func(*args,**kwargs): # Inner Function
        # Something to do before the func call
        value = func(*args,**kwargs)
        # Something to do after the func call
        return value
    return inner_func

@decorator
def target_function(*args,**kwargs):
    # Function body
    pass

target_function()

def param_decorator(param0,param1,param2): # Params Function
    def wrap_func(func): # Wrap Function
       def inner_func(*args,**kwargs): # Inner Function
            # Something to do before the func call
            value = func(*args,**kwargs)
            # Something to do after the func call
            return value
       return inner_func
    return wrap_func

@param_decorator(1,2,3)
def target_function(*args,**kwargs):
    # Function body
    pass
target_function()

