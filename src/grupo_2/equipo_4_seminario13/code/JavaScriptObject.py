class JavaScriptObject(object):
    prototype = None
    def __init__(self):
        self.__proto__ = JavaScriptObject.prototype
    def __getattr__(self, item):
        try:
            return getattr(self.__proto__,item)
        except:
            print("undefined")
            return
    
    """
      Boolean que indica si el objeto tiene property
      como miembro propio de la instancia
    """
   
    def Property(self, property):
        return property in self.__dict__

    """
    Permite el comportamiento de similitud entre
    obj["attr"] = value y obj.attr = value 
    """
    def __setitem__(self, key, value):
        setattr(self, key, value)

    def __getitem__(self, item):
        return getattr(self,item)
    

    """
    Función create de Object en Javascript que permite que el
    nuevo objeto tenga como prototipo el parámetro pasado
    """
    @staticmethod
    def create(object):
        obj = JavaScriptObject()
        obj.__proto__ = object
        return obj

    def PrototypeOf(self,obj):
        if obj.__proto__ == None:
            return False
        return obj.__proto__ == self or self.PrototypeOf(obj.__proto__)

    def JavaScriptContructObject(function):
        cls = type(function.__name__, (JavaScriptObject,), {})
        cls.prototype = JavaScriptObject()
        def init(*args):
            args[0].__proto__ = cls.prototype
            function(*args)
        cls.__init__ = init
        return cls

    @JavaScriptContructObject
    def Person(self, name):
        self.name = name

    @JavaScriptContructObject
    def Author(self,edad):
        self.edad = edad

    print("~~~~~~~~~~~~~~~~~~~~testing~~~~~~~~~~~~~~~~~~~~")

    print("~~~~~~Object.create~~~~~~")
    obj = JavaScriptObject.create(Author(35))
    print(obj)
    print(obj.edad)
    print(obj.__proto__.edad)

    print("~~~~~~~~~~~~~~~Property~~~~~~~~~~~~~~~~")
    obj.x = 25
    print(obj.Property("x"))
    print(obj.Property("edad"))
    print()

    print("~~~~~~~~~~~PrototypeOf~~~~~~~~~~~~~")
    print("a = Author(45)")
    a = Author(45)
    print("Author.prototype.PrototypeOf(a)")
    print(Author.prototype.PrototypeOf(a))
    print("Person.prototype.PrototypeOf(a)")
    print(Person.prototype.PrototypeOf(a))

    print("~~~~~~~~~~~~~~~~~~~~~")

    p = Person("person1")
    print(Person.prototype)

    Person.prototype.last = "person2"
    print(Person.prototype.last)

    p.a = 15
    Person.prototype.hide = "hide"
    def x():
        print("bla")
    Person.prototype.f = x
    p.f()

    print(p.last)
    print(p.a)
    print(p.hide)

    pb = Person("blablabla")
    print(pb.last)
    print(pb.a)

    print("~~~~~~~~~~~~~~~~~~~~~")

    aut = Author(50)
    Author.prototype.k = 10
    print(aut.k)
    print(aut.edad)
    print(aut['k'])
    print(aut.__proto__)
