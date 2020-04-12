"""
Class Decorators

Class
"""
class ArgumentClassDecoratorClass:
    def __init__(self,*args,**kwargs): # Params Function
        self.args = args
        self.kwargs = kwargs
        
    def __call__(self, Cls): # Wrap Function
        # Something to do before instance a class
        
        class InnerClass(Cls):
            # Additional Attributes
            def __init__(self2, *args, **kwargs):
                print('Creating Decorated Instance')
                super().__init__(*args,**kwargs)
                self2.attr = self.args
                # Adding extra content
            
            def __getattribute__(self,name):
                # Do something before get the attributes  
                print('Getting attribute',name,'in InnerClass')      
                x = super().__getattribute__(name)
                print('Attribute',name,'receive in InnerClass')      
                # Do something after get the attributes        
                return x            
        
        return InnerClass

@ArgumentClassDecoratorClass(1,2,3,4)
class DummyClass:
    def __init__(self):
        print('Creating TestClass Instance')
        self.attr = 0
    def test(self):
        print('Print attr',self.attr)

a = DummyClass()
a.test()

class ClassDecoratorClass:
    
    def __init__(self,Cls): # Wrap Function
        
        class InnerClass(Cls):
            # Additional Attributes
            def __init__(self, *args, **kwargs):
                print('Creating Decorated Instance')
                super().__init__(*args,**kwargs)
                self.attr = 'Value changed in Decorated Class'
                # Adding extra content
            
            def __getattribute__(self,name):
                # Do something before get the attributes  
                print('Getting attribute',name,'in InnerClass')      
                x = super().__getattribute__(name)
                print('Attribute',name,'receive in InnerClass')      
                # Do something after get the attributes        
                return x
        
        self.Cls = InnerClass
    
    def __call__(self, *args,**kwargs): # Inner Function
        # Something to do before instance a class
        Cls = self.Cls(*args,**kwargs)
        # Something to do after instance a class
        return Cls
    
@ClassDecoratorClass
class DummyClass:
    def __init__(self):
        print('Creating TestClass Instance')
        self.attr = 0
    def test(self):
        print('Print attr',self.attr)

a = DummyClass()
a.test()


"""
Class Decorators

Function
"""

def class_decorator(Cls): # Wrap Function
    class InnerClass(Cls):
        # Additional Attributes
        def __init__(self, *args, **kwargs):
            print('Creating Decorated Instance')
            super().__init__(*args,**kwargs)
            self.attr = 'Value changed in Decorated Class'
            # Adding extra content
        
        def __getattribute__(self,name):
            # Do something before get the attributes  
            print('Getting attribute',name,'in InnerClass')      
            x = super().__getattribute__(name)
            print('Attribute',name,'receive in InnerClass')      
            # Do something after get the attributes        
            return x
    
    return InnerClass

@class_decorator
class DummyClass:
    def __init__(self):
        print('Creating TestClass Instance')
        self.attr = 0
    def test(self):
        print('Print attr',self.attr)

a = DummyClass()
a.test()

def class_param_decorator(*pargs): # Params Function
    def wrap_func(Cls): # Wrap Function
        class InnerClass(Cls):
            # Additional Attributes
            def __init__(self, *args, **kwargs):
                print('Creating Decorated Instance')
                super().__init__(*args,**kwargs)
                self.attr = pargs
                # Adding extra content
            
            def __getattribute__(self,name):
                # Do something before get the attributes  
                print('Getting attribute',name,'in InnerClass')      
                x = super().__getattribute__(name)
                print('Attribute',name,'receive in InnerClass')      
                # Do something after get the attributes        
                return x
            
        return InnerClass
    return wrap_func

@class_param_decorator(1,2,3)
class DummyClass:
    def __init__(self):
        print('Creating TestClass Instance')
        self.attr = 0
    def test(self):
        print('Print attr',self.attr)

a = DummyClass()
a.test()