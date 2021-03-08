from annotate_decorator import clean_func_input

def typeCheckParams(**kwargs): # Params Function
    """
    Receive key,value pairs in witch the key are the param name, and the value are a type or an iterable of types, that must match with the current argument in the function call.\n
    Beacause of the Python syntax the return value is captured by the key 'returnx'
    """
    errors = []
    # Check if all values are a type or an iterable of types
    for x,value in kwargs.items():
        if not (hasattr(value,'__iter__') or isinstance(value,type)):
            errors.append('The vales of the decorator must be an iterable of types or a type')
        
        try: # Checking if is iterable (is not enough with checking if has __iter__)
            for y in value:
                if not isinstance(y,type):
                    errors.append('The vales of the decorator must be an iterable of types')
                    break
        except TypeError: # Not an iterable
            if isinstance(value,type):
                kwargs[x] = [value,] # Convert the type instance in a iterable of one for later code simplification
            else:
                errors.append('The vales of the decorator must be an iterable of types')
    if errors:
        raise TypeError(*errors)
    
    def wrap(fn): # Wrap Function

        # Gathering func info        
        arg_count = fn.__code__.co_argcount
        arg_list = fn.__code__.co_varnames # tuple with the function params names
        defaults = fn.__defaults__ # tuple with function default values
            
        def inner(*args, **i_kwargs): # Inner Function
            
            args,i_kwargs = clean_func_input(arg_count,arg_list,defaults,*args,**i_kwargs)
            
            # Check Types
            for i,arg in enumerate(arg_list):
                if arg in kwargs:
                    typex =  kwargs[arg]
                    for possible_type in typex:
                        if isinstance(args[i],possible_type):
                            break
                    else:
                        errors.append(f"Wrong Type in argument '{arg}' of function '{fn.__name__}' \nExpected {typex} receive {type(args[i])}")
            if errors:
                raise TypeError(*errors)
            
            value = fn(*args,**i_kwargs)
            
            if 'returnx' in kwargs:
                typex = kwargs['returnx']
                for possible_type in typex:
                    if isinstance(value,possible_type):
                        break
                else:
                    errors.append(f"Wrong Type in return value of function '{fn.__name__}' \nExpected {typex} receive {type(value)}")
                    raise TypeError(*errors)
            return value
        return inner
    return wrap

# Multiple types for an argument. a can be an int or a string
@typeCheckParams(a=[int,float])
def fn(a):
    return a

@typeCheckParams(a=int,c=str,d=float,returnx=str) # Equivalent decorator to the annotations of the first example.
def fn(a:int,b=2,c:str='10',d:float='float',*args,**kwargs)->str:
    print(a,b,c,d,args,kwargs)
    return "7"

# TypeError d:float but d is str
# fn(1)

fn(1,d=1.0)

fn(1,"b type does matter",d=1.0)

fn(1,2,'3',4.0,5,6,7,e=8,n=9)

fn(d=1.0,c='c',b=str,a=0,e=8,n=9)