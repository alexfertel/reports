class JavaScriptObject:
    def __init__(self, *args, **kwargs):
        for arg in args:
            self.__dict__.update(arg)
        
        self.__dict__.update(kwargs)
    
    def __getitem__(self, name):
        return self.__dict__.get(name, None)
    
    def __setitem__(self, name, val):
        return self.__dict__.__setitem__(name, val)
    
    def __delitem__(self, name):
        if name in self.__dict__.keys():
            del self.__dict__[name]
    
    def __getattr__(self, name):
        return self.__getitem__(name)

    def __setattr__(self, name, val):
        return self.__setitem__(name, val)
    
    def __delattr__(self, name):
        return self.__delitem__(name)

    def __iter__(self):
        return self.__dict__.__iter__()
    
    def __repr__(self):
        return self.__dict__.__repr__()
    
    def __str__(self):
        return self.__dict__.__str__()

# Funcionalidades de JavaScript
obj = JavaScriptObject(x=1, y=2.4, z='abc')
print(obj.x, obj.y, obj.z, obj.w) # 1 2.4 'abc' None
print(obj) # {'x': 1, 'y': 2.4, 'z': 'abc'}

obj.foo = lambda x : x ** 2
print(obj.foo(2)) # 4

del obj.x
print(obj.x) # None

obj['x'] = 123
print(obj['x'], obj.x) # 123 123

for prop in obj:
    print(prop, "=", obj[prop])

print(JavaScriptObject() == JavaScriptObject()) # False (dos instancias no son iguales aun si tienen los mismos valores)
print(JavaScriptObject() is JavaScriptObject()) # False (Lo mismo de arriba)

print('y' in obj) # True
print('w' in obj) # False
