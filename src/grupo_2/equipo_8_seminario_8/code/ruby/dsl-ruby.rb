
#----------------MODULE----------------
# Un modulo(module) es una coleccion de metodos, constantes y variables de clases
# Se define de la misma forma que una clase pero con la keyword 'module' y no 'class'

# ----------------SEND------------------
#send es un metodo que puede ser llamado desde cualquier instancia. Como primer parametro
# se le pasa el nombre del metodo al que se quiere acceder en la instancia
# y despues los parametros de entrada de dicho metodo.
# Aqui se hace el uso particular de pasarle el nombre de un atributo concatenado con '='
# que llama al metodo set de dicho atributo y despues se le pasa el valor que se quiere
# guardar en dicho atributo. 

#-----------------INSTANCE_EVAL---------
#instance_eval es un metodo que sera utiilzado en multiples metodos a continuacion.
#De manera general se utiliza con dos objetivos primarios:
#  - Acceder a variables internas
#  - Agregar metodos a una clase

#Start - Accediendo a variables internas:
class User
  def initialize(email)
    @email = email
  end
end

u = User.new('ruby@devscoop.fr')

u.instance_eval('@email')  # returns: "ruby@devscoop.fr"
u.instance_eval { @email } # returns: "ruby@devscoop.fr"
#End - Accediendo a variables internas.

#Start - Agregar metodos a una clase:
array_second = <<-RUBY
def second
  self[1]
end
RUBY

a = [1, 2, 3]
a.instance_eval(array_second)
#Aqui basicamente el codigo que conforma los repectivos metodos encerrados
# en array_second, es agregado a la instancia
# 'a'. O sea ahora 'a' contiene un metodo 'second'

a.second  # returns: 2

str = "ruby.devscoop.fr"
str.instance_eval do
  def /(delimiter)
    split(delimiter)
  end
end
# Se agrega el metodo '/' a dicha instancia de un string. SOLO a dicha instancia


str / '.' # returns: ["ruby", "devscoop", "fr"]

#End - Agregar metodos a una clase


#------------Implementacion de DSL---------

class Person
  attr_accessor :FirstName, :LastName
end
module Factory
    @registry = {}
   
    def self.registry
      @registry
    end

    def self.define(&block)
      definition = Definition.new
      if block_given?       
        definition.instance_eval(&block)
      end
    end

    def self.build(clazz, overrides = {})
      instance = clazz.new  
      
      # Es una forma de insertar metodos a dicha instancia
      # de una clase     
      class <<instance    
        # Se le agrega un metodo a dicha instancia que nos va a permitir
        # crear nuevos atributos en dicha instancia
        def new_attr name1 
          singleton_class.class_eval{attr_accessor "#{name1}"}
        end
      end
      #Registry tiene las clases que se han definido
      # con sus respectivos atributos.
      #Realizando la operacion merge se sobreescriben los valores de los 
      # valores que coincidan y se agregan aquellos que no estaban con anterioridad
      #Aquellos valores que son recientemente almacenados como atributos no 
      # son atributos reales de la instancia. Entonces se utiliza el metodo para agregar 
      # dichos a la instancia       
      attrs = registry[clazz].attributes.merge(overrides)
      attrs.each do |name, value|
        begin #try
          instance.send("#{name}=", value)
        rescue #except         
          instance.new_attr name
          instance.send("#{name}=", value)        
        end        
      end
      instance
    end
   
    class Builder
      attr_reader :attributes
   
      def initialize
        @attributes = {}
      end   
    end
   
    class Definition
        def New(clazz, &block)
          builder = Builder.new
          if block_given?
            builder.instance_eval(&block)
          end
          Factory.registry[clazz] = builder
        end
    end
   
    
   
    
  end

 # Factory.define "Factory" do
 #   factory Person do
 #     FirstName  ""
 #     LastName ""
 #   end
 # end

 # 'do' es una forma de definir un bloque de codigo y se mantiene la necesidad
 # de 'end' para concretarlop
  Factory.define do   
    New Person 
  end
   
  p1 = Factory.build(Person)
  p1.FirstName = "Louis"
  p1.LastName = "Dejardin"  
  p p1  
  


  #---- Los atributos se agregan de forma dinamica-------
  p2 = Factory.build(Person, FirstName: "Louis", LastName: "Dejardin")
  p "--------------"
  p p2
     
  p3 = Factory.build(Person, FirstName: "Louis", LastName: "Dejardin", Manager: Factory.build(Person, FirstName: "Bertrand", LastName: "Le Roy"))
  p "--------------"
  p p3

  