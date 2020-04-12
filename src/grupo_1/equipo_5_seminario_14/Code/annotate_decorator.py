import typing

def clean_func_input(arg_count,arg_list,defaults,*args,**kwargs):
    args = list(args)
    len_args = len(args)
    
    # Checking kwargs for double reference
    explicit_args = arg_list[:min(len_args,arg_count)] # Anything beyond the arg_count belongs to *args
    for name in explicit_args:
        if name in kwargs:
            # Raise a TypeError
            fn(*args,**kwargs)        
            
    # Inserting the defaults values
    default_offset = len_args + len(defaults) - arg_count
    for index in range(len_args,arg_count):
        default_index = index - len_args + default_offset
        default_name = arg_list[index]
        if default_name in kwargs:
            args.insert(arg_count-1,kwargs[default_name])
            kwargs.__delitem__(default_name) # Deleting params kwargs from kwargs
        else:
            args.insert(arg_count-1, defaults[default_index])
    
    return args,kwargs # funcion args and kwargs in order of declaration

def typeCheck(fn): # Wrap Function
    """
    Check if the function 'fn' behaves according its annotations
    The annotations must be a 'type' instance 
    """
    # Gathering func info        
    types = typing.get_type_hints(fn) # types = fn.__annotations__ also work
    arg_count = fn.__code__.co_argcount
    arg_list = fn.__code__.co_varnames # tuple with the function params names
    defaults = fn.__defaults__ # tuple with function default values
    
    def inner_typeCheck(*args,**kwargs): # Inner Function
        
        args,kwargs = clean_func_input(arg_count,arg_list,defaults,*args,**kwargs)
        
        # Checking arguments types
        errors = []
        for arg,arg_type in types.items():
            if arg == 'return': continue
            index = arg_list.index(arg)
            if isinstance(arg_type,type) and not isinstance(args[index],arg_type):
                errors.append(f"Wrong Type in argument '{arg}' of function '{fn.__name__}' \nExpected {arg_type} receive {type(args[index])}")
        
        if not errors:
            
            # Calling the function
            return_value = fn(*args,**kwargs)

            # Checking return type
            if 'return' in types:
                if isinstance(types['return'],type) and not isinstance(return_value,types['return']):
                    errors.append(f"Wrong Type in return value of function '{fn.__name__}' \nExpected {types['return']} receive {type(return_value)}")
                    raise TypeError(*errors)
            
            return return_value
        
        raise TypeError(*errors)
    
    return inner_typeCheck

@typeCheck
def fn(a:int,b=2,c:str='10',d:float='float',*args,**kwargs)->str:
    print(a,b,c,d,args,kwargs)
    return "7"

# TypeError d:float but d is str
# fn(1)

fn(1,d=1.0)

fn(1,"b type dont matter",d=1.0)

fn(1,2,'3',4.0,5,6,7,e=8,n=9)

fn(d=1.0,c='c',b=str,a=0,e=8,n=9)